using Demo.Framework.Web;
using Framework.Extension;
using Memorabilia.Application.Features.Admin.Pewters;
using Memorabilia.Blazor.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Pewters
{
    public partial class Pewters : ComponentBase
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
        private PewtersViewModel _viewModel = new();

        private bool FilterFunc1(PewterViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetPewters.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Pewter");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Pewters.Single(pewter => pewter.Id == id);
            var viewModel = new SavePewterViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SavePewter.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Pewters.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(PewterViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
