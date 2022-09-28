

using Memorabilia.Application.Features.Admin.ItemTypeBrand;
using Memorabilia.Blazor.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeBrands
{
    public partial class ItemTypeBrands : ComponentBase
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
        private ItemTypeBrandsViewModel _viewModel = new();

        private bool FilterFunc1(ItemTypeBrandViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetItemTypeBrands.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Brand");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.ItemTypeBrands.Single(ItemTypeBrand => ItemTypeBrand.Id == id);
            var viewModel = new SaveItemTypeBrandViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveItemTypeBrand.Command(viewModel)).ConfigureAwait(false);

            _viewModel.ItemTypeBrands.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ItemTypeBrandViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.BrandName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
