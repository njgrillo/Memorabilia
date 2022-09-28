

using Memorabilia.Application.Features.Admin.Divisions;
using Memorabilia.Blazor.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Divisions
{
    public partial class Divisions : ComponentBase
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
        private DivisionsViewModel _viewModel = new();

        private bool FilterFunc1(DivisionViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetDivisions.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Division");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Divisions.Single(Division => Division.Id == id);
            var viewModel = new SaveDivisionViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveDivision.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Divisions.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(DivisionViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (!viewModel.ConferenceName.IsNullOrEmpty() &&
                    viewModel.ConferenceName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                   (!viewModel.LeagueName.IsNullOrEmpty() &&
                    viewModel.LeagueName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                   (!viewModel.Abbreviation.IsNullOrEmpty() &&
                    viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
