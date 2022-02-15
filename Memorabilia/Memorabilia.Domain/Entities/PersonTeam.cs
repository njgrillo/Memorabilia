namespace Memorabilia.Domain.Entities
{
    public class PersonTeam : Framework.Domain.Entity.DomainEntity
    {
        public PersonTeam() { }

        public PersonTeam(int personId, int teamId, int? beginYear, int? endYear)
        {
            PersonId = personId;
            TeamId = teamId;
            BeginYear = beginYear;
            EndYear = endYear;
        }

        public int? BeginYear { get; private set; }

        public int? EndYear { get; private set; }

        public int PersonId { get; private set; }

        public int TeamId { get; private set; }

        public void Set(int teamId, int? beginYear, int? endYear)
        {
            TeamId = teamId;
            BeginYear = beginYear;
            EndYear = endYear;
        }
    }
}
