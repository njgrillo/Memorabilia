namespace Memorabilia.Blazor.Controls.TypeAhead;

public class RecordTypeAutoComplete : DomainEntityAutoComplete<RecordType>
{
    [Parameter]
    public Sport[] Sports { get; set; } = Array.Empty<Sport>();

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
        Items = Sports != null && Sports.Any() 
            ? RecordType.GetAll(Sports) 
            : RecordType.All;
    }
}
