using System.Linq;
using System.Threading.Tasks;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Repositories;
using Hlopov.CreditBroker.Identification.Infrastructure.Data;
using Hlopov.CreditBroker.Identification.Infrastructure.Repository.Base;

namespace Hlopov.CreditBroker.Identification.Infrastructure.Repository
{
    public class DeviceRepository : Repository<UserDevice>, IDeviceRepository
    {
        public DeviceRepository(IdentityContext context) : base(context)
        {
        }

        public async Task<UserDevice> GetDeviceByName(string name)
        {
            var device = (await GetAsync(x => x.Name == name)).FirstOrDefault();
            return device;
        }

        public async Task<UserDevice> GetDeviceByToken(string token)
        {
            var device = (await GetAsync(x => x.Token == token)).FirstOrDefault();
            return device;
        }
    }
}