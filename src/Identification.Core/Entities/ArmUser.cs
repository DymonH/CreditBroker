using System;
using System.Collections.Generic;
using Hlopov.CreditBroker.Identification.Core.Entities.Base;

namespace Hlopov.CreditBroker.Identification.Core.Entities
{
    public class ArmUser : GuidEntity
    {
        public string Login { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsActive { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
            
        public string RecoveryToken { get; set; }
        
        public DateTime? RecoveryTokenExpireDate { get; set; }

        public ICollection<ArmUserPhone> Phones { get; set; }

        public ICollection<UserDevice> Devices { get; set; }

        public ICollection<Department> LeadedDepartments { get; set; }

        public Position Position { get; set; }

        public Guid? PositionId { get; set; }

        public Department Department { get; set; }

        public Guid? DepartmentId { get; set; }

        public static ArmUser Create(
            Guid id,
            string login,
            string name,
            DateTime birthdate,
            bool isActive,
            string passwordHash = null,
            string passwordSalt = null,
            string recoveryToken = null,
            DateTime? recoveryTokenExpireDate = null,
            Guid? positionId = null,
            Guid? departmentId = null)
        {
            var armUser = new ArmUser
            {
                Id = id,
                Login = login,
                Name = name,
                BirthDate = birthdate,
                IsActive = isActive,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                RecoveryToken = recoveryToken,
                RecoveryTokenExpireDate = recoveryTokenExpireDate,
                PositionId = positionId,
                DepartmentId = departmentId
            };

            return armUser;
        }
    }
}