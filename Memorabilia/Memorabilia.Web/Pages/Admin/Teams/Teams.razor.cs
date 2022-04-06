using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.Teams;
using Memorabilia.Web.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Teams
{
    public partial class Teams : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        private string _search;
        private TeamsViewModel _viewModel = new();

        private bool FilterFunc1(TeamViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetTeams.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Team");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Teams.Single(team => team.Id == id);
            var viewModel = new SaveTeamViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveTeam.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Teams.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(TeamViewModel viewModel, string search)
        {
            var isYear = int.TryParse(search, out var year);

            return search.IsNullOrEmpty() ||
                   viewModel.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (!viewModel.Nickname.IsNullOrEmpty() &&
                    viewModel.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                   (!viewModel.Abbreviation.IsNullOrEmpty() &&
                    viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                   (isYear && viewModel?.BeginYear == year) ||
                   (isYear && viewModel?.EndYear == year);
        }
    }
}
