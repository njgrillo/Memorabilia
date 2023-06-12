﻿namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class DivisionTeamEditor 
    : EditTeamItem<TeamDivisionsEditModel, TeamDivisionModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveTeamDivision.Command(TeamId, EditModel.Divisions));
    }

    protected async Task OnLoad()
    {
        Initialize();

        Entity.TeamDivision[] divisions = await QueryRouter.Send(new GetTeamDivisions(TeamId));

        EditModel.Divisions = divisions.ToEditModelList();

        EditModel.SportLeagueLevel = SportLeagueLevel.Find(SportLeagueLevelId);
    }    
}
