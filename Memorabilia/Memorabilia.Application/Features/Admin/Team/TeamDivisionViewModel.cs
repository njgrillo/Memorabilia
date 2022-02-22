namespace Memorabilia.Application.Features.Admin.Team
{
    public class TeamDivisionViewModel
    {
        private readonly Domain.Entities.TeamDivision _teamDivision;

        public TeamDivisionViewModel() { }

        public TeamDivisionViewModel(Domain.Entities.TeamDivision teamDivision)
        {
            _teamDivision = teamDivision;
        }

        public int? BeginYear => _teamDivision.BeginYear;

        public int DivisionId => _teamDivision.DivisionId;

        public int? EndYear => _teamDivision.EndYear;

        public int Id => _teamDivision.Id;

        public int TeamId => _teamDivision.TeamId;
    }
}
