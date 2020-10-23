using System.Threading.Tasks;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Repositories.Base;

namespace Hlopov.CreditBroker.Identification.Core.Repositories
{
    public interface IDeviceRepository : IRepository<UserDevice>
    {
        Task<UserDevice> GetDeviceByName(string name);

        Task<UserDevice> GetDeviceByToken(string token);
    }
}