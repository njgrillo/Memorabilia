using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Web.Controls.Team
{
    public partial class TeamDivisionEditor : ComponentBase
    {
        [Parameter]
        public List<SaveTeamDivisionViewModel> Divisions { get; set; } = new();

        [Parameter]
        public SportLeagueLevel SportLeagueLevel { get; set; }

        private SaveTeamDivisionViewModel _viewModel = new ();

        private void Add()
        {
            Divisions.Add(_viewModel);

            _viewModel = new SaveTeamDivisionViewModel();
        }

        private void Remove(int divisionId, int? beginYear)
        {
            var division = Divisions.SingleOrDefault(division => division.DivisionId == divisionId && division.BeginYear == beginYear);

            if (division == null)
                return;

            division.IsDeleted = true;
        }
    }
}
