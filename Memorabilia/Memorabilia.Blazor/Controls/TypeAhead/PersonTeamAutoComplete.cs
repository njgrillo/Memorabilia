#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class PersonTeamAutoComplete : NamedEntityAutoComplete<SavePersonTeamViewModel>
{
    [Parameter]
    public int PersonId { get; set; }

    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";
        ResetValueOnEmptyText = true;

        Items = (await QueryRouter.Send(new GetTeams())).Teams.Select(team => new SavePersonTeamViewModel(PersonId, team));

        if (SportIds.Any())
        {
            Items = Items.Where(team => SportIds.Contains(team.SportId));
        }
    }
}
