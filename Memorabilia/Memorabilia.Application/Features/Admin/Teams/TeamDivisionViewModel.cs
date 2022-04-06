using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Teams
{
    public class TeamDivisionViewModel
    {
        private readonly TeamDivision _teamDivision;

        public TeamDivisionViewModel() { }

        public TeamDivisionViewModel(TeamDivision teamDivision)
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
