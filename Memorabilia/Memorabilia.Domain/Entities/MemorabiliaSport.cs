namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaSport : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaSport() { }

        public MemorabiliaSport(int memorabiliaId, int sportId)
        {
            MemorabiliaId = memorabiliaId;
            SportId = sportId;
        }

        public int MemorabiliaId { get; private set; }

        public int SportId { get; private set; }

        public void Set(int sportId)
        {
            SportId = sportId;
        }
    }
}
