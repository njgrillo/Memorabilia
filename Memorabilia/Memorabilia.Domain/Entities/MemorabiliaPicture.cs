namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaPicture : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaPicture() { }

        public MemorabiliaPicture(int memorabiliaId, 
                                  int orientationId,
                                  bool framed, 
                                  bool matted, 
                                  bool stretched, 
                                  int? photoTypeId)
        {
            MemorabiliaId = memorabiliaId;
            OrientationId = orientationId;            
            Framed = framed;
            Matted = matted;
            Stretched = stretched;
            PhotoTypeId = photoTypeId;
        }

        public bool Framed { get; set; }

        public bool Matted { get; set; }

        public int MemorabiliaId { get; private set; }

        public int OrientationId { get; private set; }

        public int? PhotoTypeId { get; private set; }

        public bool Stretched { get; private set; }

        public void Set(int orientationId, 
                        bool framed, 
                        bool matted, 
                        bool stretched, 
                        int? photoTypeId)
        {
            OrientationId = orientationId;            
            Framed = framed;
            Matted = matted;
            Stretched = stretched;
            PhotoTypeId = photoTypeId;
        }
    }
}
