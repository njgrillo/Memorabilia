using System;

namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaGame : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaGame() { }

        public MemorabiliaGame(int memorabiliaId, int authenticTypeId, int? personId, DateTime? gameDate)
        {
            MemorabiliaId = memorabiliaId;
            AuthenticTypeId = authenticTypeId;
            PersonId = personId;
            GameDate = gameDate;
        }

        public int AuthenticTypeId { get; private set; }

        public DateTime? GameDate { get; private set; }

        public int MemorabiliaId { get; private set; }

        public int? PersonId { get; private set; }

        public void Set(int authenticTypeId, int? personId, DateTime? gameDate)
        {
            AuthenticTypeId = authenticTypeId;
            PersonId = personId;
            GameDate = gameDate;
        }
    }
}