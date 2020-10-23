using System;
using System.Threading.Tasks;
using Hlopov.Common.JWT.Interfaces;
using Hlopov.Common.JWT.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hlopov.Common.JWT.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiJwtAuthentication(
            this IServiceCollection services,
            JwtOptions tokenOptions,
            IWebHostEnvironment environment)
        {
            if (tokenOptions == null)
                throw new ArgumentNullException(
                    $"{nameof(tokenOptions)} is a required parameter. " +
                    "Please make sure you've provided a valid instance with the appropriate values configured.");

            services.AddScoped<IJwtTokenHandler, JwtTokenHandler>(serviceProvider =>
                new JwtTokenHandler(tokenOptions));

            services.AddAuthorization();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.RequireHttpsMetadata = true;
                        options.SaveToken = true;
                        options.TokenValidationParameters = tokenOptions.ToTokenValidationParams();

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                                    context.Response.Headers.Add("Token-Expired", "true");

                                return Task.CompletedTask;
                            }
                        };
                    });

            return services;
        }
    }
}