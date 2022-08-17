using Demo.Framework.Web;
using Memorabilia.Application.Features.Autograph;
using Memorabilia.Application.Features.Memorabilia;
using Memorabilia.Web.Controls.Dialogs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memorabilia.Web.Pages.MemorabiliaItems
{
    public partial class Items : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public ProtectedLocalStorage LocalStorage { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        private List<MemorabiliaItemViewModel> _initialItems;
        private MemorabiliaItemsViewModel _viewModel;

        protected async Task DeleteAutograph(int id)
        {
            var itemToDelete = _viewModel.MemorabiliaItems
                                         .SelectMany(item => item.Autographs)
                                         .Single(autograph => autograph.Id == id);

            var viewModel = new SaveAutographViewModel(itemToDelete)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveAutograph.Command(viewModel)).ConfigureAwait(false);

            var memorabiliaItem = _viewModel.MemorabiliaItems.First(item => item.Id == itemToDelete.MemorabiliaId);
            memorabiliaItem.Autographs.Remove(itemToDelete);

            Snackbar.Add($"Autograph was deleted successfully!", Severity.Success);
        }

        protected async Task DeleteMemorabiliaItem(int id)
        {
            var itemToDelete = _viewModel.MemorabiliaItems.Single(item => item.Id == id);
            var viewModel = new SaveMemorabiliaItemViewModel(itemToDelete)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveMemorabiliaItem.Command(viewModel)).ConfigureAwait(false);

            _viewModel.MemorabiliaItems.Remove(itemToDelete);

            Snackbar.Add($"{itemToDelete.ItemTypeName} was deleted successfully!", Severity.Success);
        }

        protected void OnFilter(List<MemorabiliaItemViewModel> items)
        {
            _viewModel.MemorabiliaItems = items;
        }

        protected async Task OnLoad()
        {
            var userId = await LocalStorage.GetAsync<int>("UserId").ConfigureAwait(false);

            if (userId.Value == 0)
                NavigationManager.NavigateTo("Login");

            _viewModel = await QueryRouter.Send(new GetMemorabiliaItems.Query(userId.Value)).ConfigureAwait(false);
            _initialItems = _viewModel.MemorabiliaItems;
        }

        protected async Task ShowDeleteAutographConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Autograph");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await DeleteAutograph(id).ConfigureAwait(false);
        }

        protected async Task ShowDeleteMemorabiliaConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Memorabilia");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await DeleteMemorabiliaItem(id).ConfigureAwait(false);
        }

        private void ToggleChildContent(int memorabiliaItemId)
        {
            var memorabiliaItem = _viewModel.MemorabiliaItems.Single(item => item.Id == memorabiliaItemId);
            memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
            memorabiliaItem.ToggleIcon = memorabiliaItem.DisplayAutographDetails 
                ? Icons.Material.Filled.ExpandLess
                : Icons.Material.Filled.ExpandMore;
        }
    }
}
