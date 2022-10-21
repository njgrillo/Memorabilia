namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ChampionshipTeamEditor : EditTeamItem<SaveTeamChampionshipsViewModel, TeamChampionshipViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamChampionship.Command(TeamId, ViewModel.Championships));
    }

    protected async Task OnLoad()
    {
        Initialize();

        var championships = (await QueryRouter.Send(new GetTeamChampionships(TeamId)))
                                              .Select(teamChampionship => new SaveTeamChampionshipViewModel(teamChampionship))
                                              .ToList();

        ViewModel.Championships = championships;
        ViewModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
