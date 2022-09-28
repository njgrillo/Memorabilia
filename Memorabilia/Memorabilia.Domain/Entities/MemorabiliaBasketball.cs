﻿namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaBasketball : Framework.Library.Domain.Entity.DomainEntity
    {
        public MemorabiliaBasketball() { }

        public MemorabiliaBasketball(int memorabiliaId, int basketballTypeId)
        {
            MemorabiliaId = memorabiliaId;
            BasketballTypeId = basketballTypeId;
        }

        public int BasketballTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int basketballTypeId)
        {
            BasketballTypeId = basketballTypeId;
        }
    }
}
