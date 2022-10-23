#nullable disable

namespace Memorabilia.Blazor.Controls.DropDowns;

public partial class TeamDropDown : DropDown<TeamViewModel, int>
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public Franchise Franchise { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Items = (await QueryRouter.Send(new GetTeams(Franchise.Id, SportLeagueLevel.Id))).Teams;
        Label = "Team";
    }
}
