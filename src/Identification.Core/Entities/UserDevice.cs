using System;
using Hlopov.CreditBroker.Identification.Core.Entities.Base;

namespace Hlopov.CreditBroker.Identification.Core.Entities
{
    public class UserDevice : GuidEntity
    {
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid ArmUserId { get; set; }

        public ArmUser ArmUser { get; set; }

        public string Token { get; set; }

        public DateTime? TokenCreateDate { get; set; }

        public DateTime? TokenExpireDate { get; set; }

        public static UserDevice Create(
            Guid id,
            string name,
            DateTime createDate,
            Guid armUserId,
            string token,
            DateTime? tokenCreateDate,
            DateTime? tokenExpireDate)
        {
            var userDevice = new UserDevice
            {
                Id = id,
                Name = name,
                CreateDate = createDate,
                ArmUserId = armUserId,
                Token = token,
                TokenCreateDate = tokenCreateDate,
                TokenExpireDate = tokenExpireDate
            };

            return userDevice;
        }
    }
}