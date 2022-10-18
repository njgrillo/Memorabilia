using Memorabilia.Application.Features.Admin.Franchises;

namespace Memorabilia.Web.Pages.Admin.Franchises
{
    public partial class Franchises : ComponentBase
    {
        [Inject]
        public CommandRouter CommandRouter { get; set; }

        [Inject]
        public IDialogService DialogService { get; set; }

        [Inject]
        public QueryRouter QueryRouter { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        private string _search;
        private FranchisesViewModel _viewModel = new();

        private bool FilterFunc1(FranchiseViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetFranchises());
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Franchise");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id);
        }

        protected async Task Delete(int id)
        {
            var deletedItem = _viewModel.Franchises.Single(Franchise => Franchise.Id == id);
            var viewModel = new SaveFranchiseViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveFranchise(viewModel));

            _viewModel.Franchises.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(FranchiseViewModel viewModel, string search)
        {
            var isYear = int.TryParse(search, out var year);

            return search.IsNullOrEmpty() ||
                   viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (isYear && viewModel.FoundYear == year);
        }
    }
}
