namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class DivisionTeamEditor 
    : EditTeamItem<TeamDivisionsEditModel, TeamDivisionModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamDivision.Command(TeamId, EditModel.Divisions));
    }

    protected override async Task OnInitializedAsync()
    {
        Entity.TeamDivision[] divisions = await QueryRouter.Send(new GetTeamDivisions(TeamId));

        EditModel = new(TeamId, divisions.ToEditModelList())
        {
            SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId)
        };
    }    
}
