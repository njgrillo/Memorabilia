namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class ViewSportLeagueLevels : ViewItem<SportLeagueLevelsViewModel, SportLeagueLevelViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetSportLeagueLevels());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.SportLeagueLevels.Single(sportLeagueLevel => sportLeagueLevel.Id == id);
        var viewModel = new SaveSportLeagueLevelViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveSportLeagueLevel(viewModel));

        ViewModel.SportLeagueLevels.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(SportLeagueLevelViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
