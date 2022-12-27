namespace Memorabilia.Blazor.Controls.TypeAhead;

public class LeaderTypeAutoComplete : DomainEntityAutoComplete<LeaderType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    [Parameter]
    public SportLeagueLevel SportLeagueLevel { get; set; }

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Leader Type";
        Placeholder = "Search by type...";
        ResetValueOnEmptyText = true;

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
        if (SportLeagueLevel != null)
        {
            Items = LeaderType.GetAll(SportLeagueLevel);
            return;
        }

        Items = SportIds != null && SportIds.Any() ? LeaderType.GetAll(SportIds) : LeaderType.All;
    }
}
