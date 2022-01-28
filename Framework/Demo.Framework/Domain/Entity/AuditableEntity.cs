using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Domain.Entity
{
    public abstract class AuditableEntity : DomainEntity, IAuditableEntity
    {
        [Required]
        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UserId { get; set; }

        void IAuditableEntity.OnCreated(int userId)
        {
            UserId = userId;
            CreateDate = DateTime.UtcNow;
        }

        void IAuditableEntity.OnModified(int userId)
        {
            UserId = userId;
            UpdateDate = new DateTime?(DateTime.UtcNow);            
        }
    }
}
