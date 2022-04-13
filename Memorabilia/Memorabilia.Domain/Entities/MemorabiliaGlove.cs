namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaGlove : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaGlove() { }

        public MemorabiliaGlove(int memorabiliaId, int gloveTypeId)
        {
            MemorabiliaId = memorabiliaId;
            GloveTypeId = gloveTypeId;
        }

        public int GloveTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int gloveTypeId)
        {
            GloveTypeId = gloveTypeId;
        }
    }
}
