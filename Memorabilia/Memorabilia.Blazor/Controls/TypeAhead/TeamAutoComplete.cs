#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamAutoComplete : NamedEntityAutoComplete<SaveTeamViewModel>
{
    [Parameter]
    public int FranchiseId { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";
        ResetValueOnEmptyText = true;
        Items = (await QueryRouter.Send(new GetTeams(FranchiseId > 0 ? FranchiseId : null, SportLeagueLevel?.Id))).Teams.Select(team => new SaveTeamViewModel(team));        
    }
}
