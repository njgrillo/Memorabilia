namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaJersey : Framework.Library.Domain.Entity.DomainEntity
    {
        public MemorabiliaJersey() { }

        public MemorabiliaJersey(int memorabiliaId, int jerseyQualityTypeId, int jerseyStyleTypeId, int jerseyTypeId)
        {
            MemorabiliaId = memorabiliaId;
            JerseyQualityTypeId = jerseyQualityTypeId;
            JerseyStyleTypeId = jerseyStyleTypeId;
            JerseyTypeId = jerseyTypeId;
        }

        public int JerseyQualityTypeId { get; private set; }

        public int JerseyStyleTypeId { get; private set; }

        public int JerseyTypeId { get; private set; }

        public int MemorabiliaId { get; private set; }        

        public void Set(int jerseyQualityTypeId, int jerseyStyleTypeId, int jerseyTypeId)
        {
            JerseyQualityTypeId = jerseyQualityTypeId;
            JerseyStyleTypeId = jerseyStyleTypeId;
            JerseyTypeId = jerseyTypeId;
        }
    }
}
