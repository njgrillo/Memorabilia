namespace Memorabilia.Blazor.Controls.TypeAhead;

public class LeaderTypeAutoComplete : DomainEntityAutoComplete<LeaderType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

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
        Items = SportIds != null && SportIds.Any() ? LeaderType.GetAll(SportIds) : LeaderType.All;
    }
}
