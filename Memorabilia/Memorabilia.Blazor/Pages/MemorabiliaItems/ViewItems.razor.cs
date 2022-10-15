#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems
{
    public partial class ViewItems : ComponentBase
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

        [Parameter]
        public int UserId { get; set; }

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

            await CommandRouter.Send(new SaveAutograph.Command(viewModel));

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

            await CommandRouter.Send(new SaveMemorabiliaItem.Command(viewModel));

            _viewModel.MemorabiliaItems.Remove(itemToDelete);

            Snackbar.Add($"{itemToDelete.ItemTypeName} was deleted successfully!", Severity.Success);
        }

        protected void OnFilter(List<MemorabiliaItemViewModel> items)
        {
            _viewModel.MemorabiliaItems = items;
        }

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetMemorabiliaItems.Query(UserId));
            _initialItems = _viewModel.MemorabiliaItems;
        }

        protected async Task ShowDeleteAutographConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Autograph");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await DeleteAutograph(id);
        }

        protected async Task ShowDeleteMemorabiliaConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Memorabilia");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await DeleteMemorabiliaItem(id);
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
