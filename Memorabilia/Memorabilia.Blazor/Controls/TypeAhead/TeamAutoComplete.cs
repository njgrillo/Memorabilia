#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamAutoComplete : NamedEntityAutoComplete<SaveTeamViewModel>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";
        ResetValueOnEmptyText = true;
        Items = (await QueryRouter.Send(new GetTeams(SportLeagueLevelId: SportLeagueLevel?.Id))).Teams.Select(team => new SaveTeamViewModel(team));        
    }
}
