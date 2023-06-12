namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class TeamDropDown : DropDown<TeamModel, int>
{
    [Parameter]
    public Franchise Franchise { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override string GetItemDisplayText(TeamModel item)
    {
        return Franchise?.Id > 0
            ? item.NameWithYear 
            : item.Name;
    }

    protected override async Task OnInitializedAsync()
    {
        Entity.Team[] teams 
            = await QueryRouter.Send(new GetTeams(FranchiseId: Franchise?.Id, SportLeagueLevelId: SportLeagueLevel?.Id));

        Items = teams.Select(team => new TeamModel(team));
        Label = "Team";
    }
}
