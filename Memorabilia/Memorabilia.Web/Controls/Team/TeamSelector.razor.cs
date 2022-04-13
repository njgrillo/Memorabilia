﻿using Demo.Framework.Web;
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

        private async Task LoadTeams()
        {
            _teams = (await QueryRouter.Send(new GetTeams.Query(sportLeagueLevelId: SportLeagueLevel?.Id)).ConfigureAwait(false)).Teams.Select(team => new SaveTeamViewModel(team));
        }

        private async Task<IEnumerable<SaveTeamViewModel>> SearchTeams(string searchText)
        {
            if (searchText.IsNullOrEmpty())
                return Array.Empty<SaveTeamViewModel>();

            return await Task.FromResult(_teams.Where(team => team.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase))).ConfigureAwait(false);
        }

        private void TeamCheckboxClicked(bool isChecked)
        {
            _displayTeams = CanToggle && isChecked;

            if (!_displayTeams)
                _viewModel = null;

            _hasTeams = isChecked;
        }
    }
}
