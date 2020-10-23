using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Hlopov.CreditBroker.Identification.Application.Commands;
using Hlopov.CreditBroker.Identification.Application.Responses;
using Hlopov.CreditBroker.Identification.Core.Configuration;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Repositories;
using MediatR;
using Microsoft.Extensions.Options;

namespace Hlopov.CreditBroker.Identification.Application.Handlers
{
    public class IdentificationHandler : IRequestHandler<IdentificationCommand, IdentificationResponse>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUserRepository _userRepository;
        private readonly IdentificationOptions _options;

        public IdentificationHandler(
            IDeviceRepository deviceRepository,
            IUserRepository userRepository,
            IOptions<IdentificationOptions> options)
        {
            _deviceRepository = deviceRepository ?? throw new ArgumentNullException(nameof(deviceRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _options = options.Value;
        }

        public async Task<IdentificationResponse> Handle(IdentificationCommand request, CancellationToken cancellationToken)
        {
            ArmUser user = null;
            UserDevice device = null;

            if (!string.IsNullOrEmpty(request.Login) && !string.IsNullOrEmpty(request.Password))
            {
                user = await _userRepository.GetUserByCredentials(request.Login, request.Password);
                if (user != null)
                    await UpdateUserDevice(user, request.Device);
            }
            else if (!string.IsNullOrEmpty(request.Token))
            {
                device = await _deviceRepository.GetDeviceByToken(request.Token);
                if (device != null && device.Name == request.Device)
                    user = device.ArmUser;
            }

            var response = new IdentificationResponse
            {
                 Login = user.Login,
                 Name = user.Name,
                 RefreshToken = device.Token,
                 RefreshTokenExpireDate = (DateTime)device.TokenExpireDate
            };

            return response;
        }

        private async Task<UserDevice> UpdateUserDevice(ArmUser user, string deviceName)
        {
            var userDevice = user.Devices.SingleOrDefault(x => x.Name == deviceName);

            if (userDevice == null)
            {
                userDevice = UserDevice.Create(Guid.NewGuid(), deviceName, DateTime.Now, user.Id, GenerateRefreshToken(), DateTime.Now, DateTime.Now.AddMinutes(_options.RefreshTokenLifetimeMinutes));
                await _deviceRepository.AddAsync(userDevice);
            }
            else
            {
                userDevice.Token = GenerateRefreshToken();
                userDevice.TokenCreateDate = DateTime.Now;
                userDevice.TokenExpireDate = DateTime.Now.AddMinutes(_options.RefreshTokenLifetimeMinutes);
                await _deviceRepository.UpdateAsync(userDevice);
            }
            
            return userDevice;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}