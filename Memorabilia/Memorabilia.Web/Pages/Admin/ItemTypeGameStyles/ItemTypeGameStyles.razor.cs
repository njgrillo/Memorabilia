

using Memorabilia.Application.Features.Admin.ItemTypeGameStyle;
using Memorabilia.Blazor.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.Admin.ItemTypeGameStyles
{
    public partial class ItemTypeGameStyles : ComponentBase
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
        private ItemTypeGameStylesViewModel _viewModel = new();

        private bool FilterFunc1(ItemTypeGameStyleViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetItemTypeGameStyles.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Game Style");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        protected async Task Delete(int id)
        {
            var deletedItem = _viewModel.ItemTypeGameStyles.Single(itemTypeGameStyle => itemTypeGameStyle.Id == id);
            var viewModel = new SaveItemTypeGameStyleViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveItemTypeGameStyle.Command(viewModel)).ConfigureAwait(false);

            _viewModel.ItemTypeGameStyles.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ItemTypeGameStyleViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.GameStyleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
