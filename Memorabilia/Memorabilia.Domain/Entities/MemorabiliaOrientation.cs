namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaOrientation : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaOrientation() { }

        public MemorabiliaOrientation(int memorabiliaId, int orientationId)
        {
            MemorabiliaId = memorabiliaId;
            OrientationId = orientationId;
        }        

        public int MemorabiliaId { get; private set; }

        public int OrientationId { get; private set; }

        public void Set(int orientationId)
        {
            OrientationId = orientationId;
        }
    }
}
