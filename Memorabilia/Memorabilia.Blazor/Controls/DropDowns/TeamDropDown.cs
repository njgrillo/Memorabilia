

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class TeamDropDown : DropDown<TeamViewModel, int>
{
    [Parameter]
    public Franchise Franchise { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override string GetItemDisplayText(TeamViewModel item)
    {
        return Franchise?.Id > 0
            ? item.NameWithYear 
            : item.Name;
    }

    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetTeams(Franchise?.Id, SportLeagueLevel?.Id))).Teams;
        Label = "Team";
    }
}
