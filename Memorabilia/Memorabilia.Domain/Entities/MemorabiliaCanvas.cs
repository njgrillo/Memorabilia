namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaCanvas : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaCanvas() { }

        public MemorabiliaCanvas(int memorabiliaId, bool framed, bool stretched)
        {
            MemorabiliaId = memorabiliaId;
            Framed = framed;
            Stretched = stretched;
        }

        public bool Framed { get; set; }        

        public int MemorabiliaId { get; private set; }

        public bool Stretched { get; set; }

        public void Set(bool framed, bool stretched)
        {
            Framed = framed;
            Stretched = stretched;
        }
    }
}
