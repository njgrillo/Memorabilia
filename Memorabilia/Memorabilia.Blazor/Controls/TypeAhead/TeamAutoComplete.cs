#nullable disable

namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamAutoComplete : Autocomplete<SaveTeamViewModel>
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private IEnumerable<SaveTeamViewModel> Teams = Enumerable.Empty<SaveTeamViewModel>();

    protected override async Task OnInitializedAsync()
    {
        Label = "Team";
        Placeholder = "Search by team...";
        ResetValueOnEmptyText = true;
        Teams = (await QueryRouter.Send(new GetTeams(SportLeagueLevelId: SportLeagueLevel?.Id))).Teams.Select(team => new SaveTeamViewModel(team));        
    }

    protected override string GetItemSelectedText(SaveTeamViewModel item)
    {
        return item?.DisplayName;
    }

    protected override string GetItemText(SaveTeamViewModel item)
    {
        return item?.DisplayName;
    }

    public override async Task<IEnumerable<SaveTeamViewModel>> Search(string searchText)
    {
        if (searchText.IsNullOrEmpty())
            return Array.Empty<SaveTeamViewModel>();

        return await Task.FromResult(Teams.Where(team => team.DisplayName.Contains(searchText, StringComparison.OrdinalIgnoreCase)));
    }
}
