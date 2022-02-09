namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaPhoto : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaPhoto() { }

        public MemorabiliaPhoto(int memorabiliaId, int photoTypeId, bool framed)
        {
            MemorabiliaId = memorabiliaId;
            PhotoTypeId = photoTypeId;
            Framed = framed;
        }

        public bool Framed { get; set; }

        public int MemorabiliaId { get; private set; }

        public int PhotoTypeId { get; private set; }

        public void Set(int photoTypeId, bool framed)
        {
            PhotoTypeId = photoTypeId;
            Framed = framed;
        }
    }
}
