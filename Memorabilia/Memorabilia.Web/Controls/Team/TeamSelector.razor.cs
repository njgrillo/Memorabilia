using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Domain.Constants;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Controls.Team
{
    public partial class TeamSelector : ComponentBase
    {
        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Parameter]
        public bool AllowMultiple { get; set; }

        [Parameter]
        public bool CanToggle { get; set; }

        [Parameter]
        public ItemType ItemType { get; set; }

        [Parameter]
        public SportLeagueLevel SportLeagueLevel { get; set; }

        [Parameter]
        public SaveTeamViewModel SelectedTeam { get; set; }

        [Parameter]
        public EventCallback<SaveTeamViewModel> SelectedTeamChanged { get; set; }

        [Parameter]
        public List<SaveTeamViewModel> Teams { get; set; } = new();

        SaveTeamViewModel _viewModel
        {
            get => SelectedTeam;
            set
            {
                SelectedTeam = value;
                SelectedTeamChanged.InvokeAsync(value);
            }
        }

        private bool _canAdd = true;
        private bool _displayTeams;
        private bool _hasTeams;
        private string _itemTypeNameLabel => $"Associate {ItemType.Name} with a Team";
        private IEnumerable<SaveTeamViewModel> _teams = Enumerable.Empty<SaveTeamViewModel>();

        protected override async Task OnInitializedAsync()
        {
            _displayTeams = !CanToggle || SelectedTeam?.Id > 0 || Teams.Any();
            _hasTeams = SelectedTeam?.Id > 0 || Teams.Any();

            await LoadTeams().ConfigureAwait(false);
        }

        private void Add()
        {
            var team = Teams.SingleOrDefault(team => team.Id == _viewModel.Id);

            if (team != null)
                team.IsDeleted = false;
            else
                Teams.Add(_viewModel);

            _viewModel = new();

            SetCanAdd();
        }

        private async Task LoadTeams()
        {
            var query = new GetTeams.Query(sportLeagueLevelId: SportLeagueLevel?.Id);

            _teams = (await QueryRouter.Send(query).ConfigureAwait(false)).Teams.Select(team => new SaveTeamViewModel(team));
        }

        private void Remove(int teamId)
        {
            var team = _teams.SingleOrDefault(team => team.Id == teamId);

            if (team == null)
                return;

            team.IsDeleted = true;

            SetCanAdd();
        }

        private async Task<IEnumerable<SaveTeamViewModel>> SearchTeams(string searchText)
        {
            if (searchText.IsNullOrEmpty())
                return Array.Empty<SaveTeamViewModel>();

            return await Task.FromResult(_teams.Where(team => team.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
        }

        private void SetCanAdd()
        {
            _canAdd = AllowMultiple || Teams.Any(team => !team.IsDeleted);
        }

        private void TeamCheckboxClicked(bool isChecked)
        {
            _displayTeams = CanToggle && isChecked;

            if (!_displayTeams)
                SelectedTeam = null;

            _hasTeams = isChecked;
        }
    }
}
