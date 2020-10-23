using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Repositories;
using Hlopov.CreditBroker.Identification.Core.Specifications;
using Hlopov.CreditBroker.Identification.Infrastructure.Data;
using Hlopov.CreditBroker.Identification.Infrastructure.Repository.Base;

namespace Hlopov.CreditBroker.Identification.Infrastructure.Repository
{
    public class UserRepository : Repository<ArmUser>, IUserRepository
    {
        public UserRepository(IdentityContext context) : base(context)
        {
        }

        public async Task<ArmUser> GetUserByCredentials(string login, string password)
        {
            var spec = new UserSpecification(login);
            var user = (await GetAsync(spec)).FirstOrDefault();

            if (user != null)
            {
                var saltBytes = Convert.FromBase64String(user.PasswordSalt);
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == user.PasswordHash
                    ? user
                    : null;
            }

            return user;
        }
    }
}