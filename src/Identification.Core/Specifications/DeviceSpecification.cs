using System;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Specifications.Base;

namespace Hlopov.CreditBroker.Identification.Core.Specifications
{
    public sealed class DeviceSpecification : BaseSpecification<UserDevice>
    {
        public DeviceSpecification(Guid id)
            : base(r => r.Id == id)
        {
        }

        public DeviceSpecification(string name)
            : base(r => r.Name == name)
        {
        }

        public DeviceSpecification()
            : base(null)
        {
        }
    }
}