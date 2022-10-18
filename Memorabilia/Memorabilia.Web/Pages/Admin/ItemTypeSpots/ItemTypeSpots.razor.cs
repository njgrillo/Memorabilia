using Memorabilia.Application.Features.Admin.ItemTypeSpots;

namespace Memorabilia.Web.Pages.Admin.ItemTypeSpots
{
    public partial class ItemTypeSpots : ComponentBase
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
        private ItemTypeSpotsViewModel _viewModel = new();

        private bool FilterFunc1(ItemTypeSpotViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetItemTypeSpots());
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Item Type Spot");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.ItemTypeSpots.Single(ItemTypeSpot => ItemTypeSpot.Id == id);
            var viewModel = new SaveItemTypeSpotViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveItemTypeSpot(viewModel));

            _viewModel.ItemTypeSpots.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(ItemTypeSpotViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.SpotName.Contains(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
