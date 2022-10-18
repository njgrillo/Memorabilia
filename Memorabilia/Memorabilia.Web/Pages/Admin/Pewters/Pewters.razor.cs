using Memorabilia.Application.Features.Admin.Pewters;

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
            _viewModel = await QueryRouter.Send(new GetPewters());
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Pewter");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Pewters.Single(pewter => pewter.Id == id);
            var viewModel = new SavePewterViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SavePewter(viewModel));

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
