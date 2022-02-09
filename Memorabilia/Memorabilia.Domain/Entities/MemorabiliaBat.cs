namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaBat : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaBat() { }

        public MemorabiliaBat(int memorabiliaId, int batTypeId, int? length)
        {
            MemorabiliaId = memorabiliaId;
            BatTypeId = batTypeId;
            Length = length;
        }

        public int BatTypeId { get; private set; }

        public int? Length { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int batTypeId, int? length)
        {
            BatTypeId = batTypeId;
            Length = length;
        }
    }
}
