namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class ViewSportLeagueLevels 
    : ViewItem<SportLeagueLevelsModel, SportLeagueLevelModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SportLeagueLevelsModel(await QueryRouter.Send(new GetSportLeagueLevels()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.SportLeagueLevels.Single(sportLeagueLevel => sportLeagueLevel.Id == id);
        var viewModel = new SportLeagueLevelEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveSportLeagueLevel(viewModel));

        ViewModel.SportLeagueLevels.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(SportLeagueLevelModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!viewModel.Abbreviation.IsNullOrEmpty() &&
            viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
