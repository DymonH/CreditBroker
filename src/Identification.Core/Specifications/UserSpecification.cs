using System;
using Hlopov.CreditBroker.Identification.Core.Entities;
using Hlopov.CreditBroker.Identification.Core.Specifications.Base;

namespace Hlopov.CreditBroker.Identification.Core.Specifications
{
    public sealed class UserSpecification : BaseSpecification<ArmUser>
    {
        public UserSpecification(Guid id)
            : base(r => r.Id == id)
        {
        }

        public UserSpecification(string login)
            : base(r => r.Login == login)
        {
        }

        public UserSpecification()
            : base(null)
        {
        }
    }
}