using System;
using Hlopov.CreditBroker.Identification.Core.Entities.Base;

namespace Hlopov.CreditBroker.Identification.Core.Entities
{
    public class ArmUserPhone : GuidEntity
    {
        public string Phone { get; set; }

        public Guid ArmUserId { get; set; }

        public ArmUser ArmUser { get; set; }

        public Guid ArmUserPhoneTypeId { get; set; }

        public ArmUserPhoneType ArmUserPhoneType { get; set; }
    }
}