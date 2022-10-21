namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class ViewLeagues : ViewItem<LeaguesViewModel, LeagueViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetLeagues());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Leagues.Single(League => League.Id == id);
        var viewModel = new SaveLeagueViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveLeague(viewModel));

        ViewModel.Leagues.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(LeagueViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
