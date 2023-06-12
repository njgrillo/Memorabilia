namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class ViewLeagues 
    : ViewItem<LeaguesModel, LeagueModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new LeaguesModel(await QueryRouter.Send(new GetLeagues()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Leagues.Single(League => League.Id == id);
        var viewModel = new LeagueEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveLeague(viewModel));

        ViewModel.Leagues.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(LeagueModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!viewModel.Abbreviation.IsNullOrEmpty() &&
            viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
