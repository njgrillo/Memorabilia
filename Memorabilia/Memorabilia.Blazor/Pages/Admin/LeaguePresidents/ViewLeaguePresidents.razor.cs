namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class ViewLeaguePresidents : ViewItem<LeaguePresidentsViewModel, LeaguePresidentViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetLeaguePresidents());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Presidents.Single(president => president.Id == id);
        var viewModel = new SaveLeaguePresidentViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveLeaguePresident(viewModel));

        ViewModel.Presidents.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(LeaguePresidentViewModel viewModel, string search)
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
