

using Memorabilia.Application.Features.Admin.Sports;
using Memorabilia.Blazor.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.Sports
{
    public partial class Sports : ComponentBase
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
        private SportsViewModel _viewModel = new();

        private bool FilterFunc1(SportViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetSports.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Sport");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Sports.Single(sport => sport.Id == id);
            var viewModel = new SaveSportViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveSport.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Sports.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(SportViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (!viewModel.AlternateName.IsNullOrEmpty() &&
                    viewModel.AlternateName.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
