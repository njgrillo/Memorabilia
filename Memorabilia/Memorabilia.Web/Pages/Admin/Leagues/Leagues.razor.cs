using Memorabilia.Application.Features.Admin.Leagues;

namespace Memorabilia.Web.Pages.Admin.Leagues
{
    public partial class Leagues : ComponentBase
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
        private LeaguesViewModel _viewModel = new();

        private bool FilterFunc1(LeagueViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetLeagues());
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete League");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.Leagues.Single(League => League.Id == id);
            var viewModel = new SaveLeagueViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveLeague(viewModel));

            _viewModel.Leagues.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(LeagueViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (!viewModel.Abbreviation.IsNullOrEmpty() &&
                    viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
