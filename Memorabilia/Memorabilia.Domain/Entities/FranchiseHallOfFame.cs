namespace Memorabilia.Domain.Entities
{
    public class FranchiseHallOfFame : Framework.Domain.Entity.DomainEntity
    {
        public FranchiseHallOfFame() { }

        public FranchiseHallOfFame(int personId, int franchiseId, int? year)
        {
            PersonId = personId;
            FranchiseId = franchiseId;
            Year = year;
        }

        public int FranchiseId { get; private set; }

        public int PersonId { get; private set; }

        public int? Year { get; private set; }

        public void Set(int franchiseId, int? year)
        {
            FranchiseId = franchiseId;
            Year = year;
        }
    }
}
