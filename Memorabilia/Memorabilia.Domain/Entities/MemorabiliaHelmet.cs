namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaHelmet : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaHelmet() { }

        public MemorabiliaHelmet(int memorabiliaId, int? helmetQualityTypeId, int? helmetTypeId)
        {
            MemorabiliaId = memorabiliaId;
            HelmetQualityTypeId = helmetQualityTypeId;
            HelmetTypeId = helmetTypeId;
        }

        public int? HelmetQualityTypeId { get; private set; }

        public int? HelmetTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }

        public void Set(int? helmetQualityTypeId, int? helmetTypeId)
        {
            HelmetQualityTypeId = helmetQualityTypeId;
            HelmetTypeId = helmetTypeId;
        }
    }
}
