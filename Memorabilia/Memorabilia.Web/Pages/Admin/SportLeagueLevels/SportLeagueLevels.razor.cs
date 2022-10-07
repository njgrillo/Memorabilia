using Memorabilia.Application.Features.Admin.SportLeagueLevels;

namespace Memorabilia.Web.Pages.Admin.SportLeagueLevels
{
    public partial class SportLeagueLevels : ComponentBase
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
        private SportLeagueLevelsViewModel _viewModel = new();

        private bool FilterFunc1(SportLeagueLevelViewModel viewModel) => FilterFunc(viewModel, _search);

        protected async Task OnLoad()
        {
            _viewModel = await QueryRouter.Send(new GetSportLeagueLevels.Query()).ConfigureAwait(false);
        }

        protected async Task ShowDeleteConfirm(int id)
        {
            var dialog = DialogService.Show<DeleteDialog>("Delete Sport League Level");
            var result = await dialog.Result;

            if (result.Cancelled)
                return;

            await Delete(id).ConfigureAwait(false);
        }

        private async Task Delete(int id)
        {
            var deletedItem = _viewModel.SportLeagueLevels.Single(sportLeagueLevel => sportLeagueLevel.Id == id);
            var viewModel = new SaveSportLeagueLevelViewModel(deletedItem)
            {
                IsDeleted = true
            };

            await CommandRouter.Send(new SaveSportLeagueLevel.Command(viewModel)).ConfigureAwait(false);

            _viewModel.SportLeagueLevels.Remove(deletedItem);

            Snackbar.Add($"{_viewModel.ItemTitle} was deleted successfully!", Severity.Success);
        }

        private static bool FilterFunc(SportLeagueLevelViewModel viewModel, string search)
        {
            return search.IsNullOrEmpty() ||
                   viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                   (!viewModel.Abbreviation.IsNullOrEmpty() &&
                    viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
        }
    }
}
