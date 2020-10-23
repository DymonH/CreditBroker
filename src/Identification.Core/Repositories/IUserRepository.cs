using System.Threading.Tasks;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Repositories.Base;

namespace Hlopov.CreditBroker.Identification.Core.Repositories
{
    public interface IUserRepository : IRepository<ArmUser>
    {
        Task<ArmUser> GetUserByCredentials(string login, string password);
    }
}