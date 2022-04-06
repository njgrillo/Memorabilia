using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.People;
using Memorabilia.Application.Features.Admin.Teams;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.Person
{
    public partial class PersonTeamSelector : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public int PersonId { get; set; }

        [Parameter]
        public List<SavePersonTeamViewModel> Teams { get; set; } = new();

        private IEnumerable<SavePersonTeamViewModel> _teams = Enumerable.Empty<SavePersonTeamViewModel>();
        private SavePersonTeamViewModel _viewModel = new ();

        protected override async Task OnInitializedAsync()
        {
            await LoadTeams().ConfigureAwait(false);
        }

        private void Add()
        {
            Teams.Add(_viewModel);

            _viewModel = new SavePersonTeamViewModel();
        }

        private async Task LoadTeams()
        {
            var query = new GetTeams.Query();

            _teams = (await QueryRouter.Send(query).ConfigureAwait(false)).Teams.Select(team => new SavePersonTeamViewModel(PersonId, team));
        }

        private void Remove(int teamPersonId)
        {
            var team = Teams.SingleOrDefault(team => team.Id == teamPersonId);

            if (team == null)
                return;

            team.IsDeleted = true;
        }

        private async Task<IEnumerable<SavePersonTeamViewModel>> SearchTeams(string searchText)
        {
            if (searchText.IsNullOrEmpty())
                return Array.Empty<SavePersonTeamViewModel>();

            return await Task.FromResult(_teams.Where(team => team.TeamDisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
        }
    }
}
