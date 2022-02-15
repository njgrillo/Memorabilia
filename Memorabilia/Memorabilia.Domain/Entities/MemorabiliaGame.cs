using System;

namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaGame : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaGame() { }

        public MemorabiliaGame(int memorabiliaId, int gameStyleTypeId, int? personId, DateTime? gameDate)
        {
            MemorabiliaId = memorabiliaId;
            GameStyleTypeId = gameStyleTypeId;
            PersonId = personId;
            GameDate = gameDate;
        }        

        public DateTime? GameDate { get; private set; }

        public int GameStyleTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public int? PersonId { get; private set; }

        public void Set(int gameStyleTypeId, int? personId, DateTime? gameDate)
        {
            GameStyleTypeId = gameStyleTypeId;
            PersonId = personId;
            GameDate = gameDate;
        }
    }
}