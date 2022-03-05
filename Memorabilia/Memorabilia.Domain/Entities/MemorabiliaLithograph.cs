namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaLithograph : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaLithograph() { }

        public MemorabiliaLithograph(int memorabiliaId, bool framed, bool matted)
        {
            MemorabiliaId = memorabiliaId;
            Framed = framed;
            Matted = matted;
        }

        public bool Framed { get; set; }

        public bool Matted { get; set; }

        public int MemorabiliaId { get; private set; }

        public void Set(bool framed, bool matted)
        {
            Framed = framed;
            Matted = matted;
        }
    }
}
