namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class ViewLeaguePresidents 
    : ViewItem<LeaguePresidentsModel, LeaguePresidentModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new LeaguePresidentsModel(await QueryRouter.Send(new GetLeaguePresidents()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Presidents.Single(president => president.Id == id);
        var viewModel = new LeaguePresidentEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveLeaguePresident(viewModel));

        ViewModel.Presidents.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(LeaguePresidentModel viewModel, string search)
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
