using Memorabilia.Application.Features.Admin.Commissioners;

namespace Memorabilia.Web.Pages.Admin.Commissioners
{
    public partial class Commissioners : ComponentBase
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
        private CommissionersViewModel _viewModel = new();

        private bool FilterFunc1(CommissionerViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetCommissioners.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Commissioner");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Commissioners.Single(Commissioner => Commissioner.Id == id);
            var viewModel = new SaveCommissionerViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveCommissioner.Command(viewModel)).ConfigureAwait(false);

            _viewModel.Commissioners.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(CommissionerViewModel viewModel, string search)
        {
            var isYear = int.TryParse(search, out var year);

            return search.IsNullOrEmpty() ||
                   viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (isYear && viewModel?.BeginYear == year) ||
                   (isYear && viewModel?.EndYear == year) ||
                   (viewModel.Person != null &&
                    viewModel.Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
