using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hlopov.CreditBroker.Identification.Infrastructure.Data
{
    public class IdentityContextSeeder
    {
        public static async Task SeedAsync(IdentityContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                // TODO: Only run this if using a real database
                await context.Database.MigrateAsync();
                await context.Database.EnsureCreatedAsync();
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<IdentityContextSeeder>();
                    log.LogError(exception.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }

                throw;
            }
        }
    }
}