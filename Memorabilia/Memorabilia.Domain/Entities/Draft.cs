namespace Memorabilia.Domain.Entities
{
    public class Draft : Framework.Domain.Entity.DomainEntity
    {
        public Draft() { }

        public Draft(int personId, int franchiseId, int year, int round, int? pick, int? overall)
        {
            PersonId = personId;
            FranchiseId = franchiseId;
            Year = year;
            Round = round;
            Pick = pick;
            Overall = overall;
        }

        public int FranchiseId { get; private set; }

        public int? Overall { get; private set; }

        public int PersonId { get; private set; }

        public int? Pick { get; private set; }

        public int Round { get; private set; }

        public int Year { get; private set; }

        public void Set(int franchiseId, int year, int round, int? pick, int? overall)
        {
            FranchiseId = franchiseId;
            Year = year;
            Round = round;
            Pick = pick;
            Overall = overall;
        }
    }
}
