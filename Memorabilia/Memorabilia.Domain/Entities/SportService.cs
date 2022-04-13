using System;

namespace Memorabilia.Domain.Entities
{
    public class SportService : Framework.Domain.Entity.DomainEntity
    {
        public SportService() { }

        public SportService(int personId, DateTime? debutDate, DateTime? freeAgentSigningDate, DateTime? lastAppearanceDate)
        {
            PersonId = personId;
            DebutDate = debutDate;
            FreeAgentSigningDate = freeAgentSigningDate;
            LastAppearanceDate = lastAppearanceDate;
        }

        public DateTime? DebutDate { get; private set; }

        public DateTime? FreeAgentSigningDate { get; private set; }

        public DateTime? LastAppearanceDate { get; private set; }

        public int PersonId { get; private set; }

        public void Set(DateTime? debutDate, DateTime? freeAgentSigningDate, DateTime? lastAppearanceDate)
        {
            DebutDate = debutDate;
            FreeAgentSigningDate = freeAgentSigningDate;
            LastAppearanceDate = lastAppearanceDate;
        }
    }
}
