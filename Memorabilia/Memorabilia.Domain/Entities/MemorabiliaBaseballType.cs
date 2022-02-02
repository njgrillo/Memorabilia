namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaBaseballType : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaBaseballType() { }

        public MemorabiliaBaseballType(int memorabiliaId, int baseballTypeId, int? year, string anniversary)
        {
            MemorabiliaId = memorabiliaId;
            BaseballTypeId = baseballTypeId;
            Year = year;
            Anniversary = anniversary;
        }

        public string Anniversary { get; private set; }

        public int BaseballTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public int? Year {get; private set;}

        public void Set(int baseballTypeId, int? year, string anniversary)
        {
            BaseballTypeId = baseballTypeId;
            Year = year;
            Anniversary = anniversary;
        }
    }
}
