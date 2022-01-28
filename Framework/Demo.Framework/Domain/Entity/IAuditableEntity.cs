using System;

namespace Framework.Domain.Entity
{
    public interface IAuditableEntity
    {
        DateTime? UpdateDate { get; }

        void OnCreated(int userId);

        void OnModified(int userId);
    }
}
