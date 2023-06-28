namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ChampionshipTeamEditor 
    : EditTeamItem<TeamChampionshipsEditModel, TeamChampionshipModel>
{   
    protected override async Task OnInitializedAsync()
    {
        Entity.Champion[] champions = await QueryRouter.Send(new GetTeamChampionships(TeamId));

        EditModel = new(TeamId, champions.ToEditModelList())
        {
            SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId)
        };
    }

    protected async Task Save()
    {
        await Save(new SaveTeamChampionship.Command(TeamId, EditModel.Championships));
    }
}
