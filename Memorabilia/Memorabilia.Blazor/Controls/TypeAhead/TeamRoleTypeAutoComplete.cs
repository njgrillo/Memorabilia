namespace Memorabilia.Blazor.Controls.TypeAhead;

public class TeamRoleTypeAutoComplete : DomainEntityAutoComplete<TeamRoleType>
{
    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private bool _loaded;

    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Role";
        Placeholder = "Search by role...";

        LoadItems();
    }

    protected override void OnParametersSet()
    {
        if (_loaded)
            return;

        LoadItems();

        _loaded = true;
    }

    private void LoadItems()
    {
        Items = SportLeagueLevel != null 
            ? TeamRoleType.Get(SportLeagueLevel) 
            : TeamRoleType.All;
    }
}
