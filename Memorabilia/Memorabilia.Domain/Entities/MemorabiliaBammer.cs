namespace Memorabilia.Domain.Entities
{
    public class MemorabiliaBammer : Framework.Library.Domain.Entity.DomainEntity
    {
        public MemorabiliaBammer() { }

        public MemorabiliaBammer(int memorabiliaId, int? bammerTypeId, bool inPackage, int? year)
        {
            MemorabiliaId = memorabiliaId;
            BammerTypeId = bammerTypeId;
            InPackage = inPackage;
            Year = year;
        }

        public int? BammerTypeId { get; private set; }

        public bool InPackage { get; private set; }

        public int MemorabiliaId { get; private set; }

        public int? Year { get; private set; }

        public void Set(int? bammerTypeId, bool inPackage, int? year)
        {
            BammerTypeId = bammerTypeId;
            InPackage = inPackage;
            Year = year;
        }
    }
}
