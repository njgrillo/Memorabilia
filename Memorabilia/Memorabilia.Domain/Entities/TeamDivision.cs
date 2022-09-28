namespace Memorabilia.Domain.Entities
{
    public class TeamDivision : Framework.Library.Domain.Entity.DomainEntity
    {
        public TeamDivision() { }

        public TeamDivision(int divisionId, int teamId, int? beginYear, int? endYear)
        {
            DivisionId = divisionId;
            TeamId = teamId;
            BeginYear = beginYear;
            EndYear = endYear;
        }

        public int? BeginYear { get; set; }

        public int DivisionId { get; set; }

        public string DivisionName => Constants.Division.Find(DivisionId)?.Name;

        public int? EndYear { get; set; }

        public virtual Team Team { get; set; }

        public int TeamId { get; set; }

        public void Set(int divisionId, int teamId, int? beginYear, int? endYear)
        {
            DivisionId = divisionId;
            TeamId = teamId;
            BeginYear = beginYear;
            EndYear = endYear;
        }
    }
}
