using System;
using System.Collections.Generic;
using Hlopov.CreditBroker.Identification.Core.Entities.Base;

namespace Hlopov.CreditBroker.Identification.Core.Entities
{
    public class Department : GuidEntity
    {
        public string Name { get; set; }

        public Department SuperiorDepartment { get; set; }

        public Guid SuperiorDepartmentId { get; set; }

        public ArmUser DepartmentHead { get; set; }

        public Guid? DepartmentHeadId { get; set; }

        public ICollection<ArmUser> ArmUsers { get; set; }
    }
}