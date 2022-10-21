namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ViewTeams : ViewItem<TeamsViewModel, TeamViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetTeams());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Teams.Single(team => team.Id == id);
        var viewModel = new SaveTeamViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveTeam.Command(viewModel));

        ViewModel.Teams.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(TeamViewModel viewModel, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               viewModel.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.Nickname.IsNullOrEmpty() &&
                viewModel.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (isYear && viewModel?.BeginYear == year) ||
               (isYear && viewModel?.EndYear == year);
    }
}
