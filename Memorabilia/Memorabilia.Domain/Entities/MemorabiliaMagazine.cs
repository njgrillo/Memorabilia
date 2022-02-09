using System;
namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaMagazine : Framework.Domain.Entity.DomainEntity
    {
        public MemorabiliaMagazine() { }

        public MemorabiliaMagazine(int memorabiliaId, DateTime? date, bool framed)
        {
            MemorabiliaId = memorabiliaId;
            Date = date;
            Framed = framed;
        }

        public DateTime? Date { get; set; }

        public bool Framed { get; set; }

        public int MemorabiliaId { get; private set; }

        public void Set(DateTime? date, bool framed)
        {
            Date = date;
            Framed = framed;
        }
    }
}
