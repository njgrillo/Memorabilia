namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaBaseballType : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaBaseballType() { }

        public MemorabiliaBaseballType(int memorabiliaId, int baseballTypeId)
        {
            MemorabiliaId = memorabiliaId;
            BaseballTypeId = baseballTypeId;
        }

        public int BaseballTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int baseballTypeId)
        {
            BaseballTypeId = baseballTypeId;
        }
    }
}
