namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaSize : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaSize() { }

        public MemorabiliaSize(int memorabiliaId, int sizeId)
        {
            MemorabiliaId = memorabiliaId;
            SizeId = sizeId;
        }        

        public int MemorabiliaId { get; private set; }

        public int SizeId { get; private set; }

        public void Set(int sizeId)
        {
            SizeId = sizeId;
        }
    }
}
