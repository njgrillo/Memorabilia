namespace Memorabilia.Blazor.Controls.TypeAhead;

public class RecordTypeAutoComplete : DomainEntityAutoComplete<RecordType>
{
    [Parameter]
    public RecordType[] RecordTypes { get; set; }
        = [];

    [Parameter]
    public Sport[] Sports { get; set; } 
        = [];

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
        if (RecordTypes.Length > 0)
        {
            Items = RecordTypes;
            return;
        }

        Items = Sports.HasAny()
            ? RecordType.GetAll(Sports) 
            : RecordType.All;
    }
}
