namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaPhoto : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaPhoto() { }

        public MemorabiliaPhoto(int memorabiliaId, int photoTypeId, bool framed, bool matted)
        {
            MemorabiliaId = memorabiliaId;
            PhotoTypeId = photoTypeId;
            Framed = framed;
            Matted = matted;
        }

        public bool Framed { get; set; }

        public bool Matted { get; set; }

        public int MemorabiliaId { get; private set; }

        public int PhotoTypeId { get; private set; }

        public void Set(int photoTypeId, bool framed, bool matted)
        {
            PhotoTypeId = photoTypeId;
            Framed = framed;
            Matted = matted;
        }
    }
}
