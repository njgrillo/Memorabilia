namespace Memorabilia.Blazor.Controls.TypeAhead;

public class RecordTypeAutoComplete : DomainEntityAutoComplete<RecordType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Record Type";
        Placeholder = "Search by record...";
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
        Items = SportIds != null && SportIds.Any() ? RecordType.GetAll(SportIds) : RecordType.All;
    }
}
