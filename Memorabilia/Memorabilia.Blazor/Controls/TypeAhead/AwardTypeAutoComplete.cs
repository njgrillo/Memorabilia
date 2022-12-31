namespace Memorabilia.Blazor.Controls.TypeAhead;

public class AwardTypeAutoComplete : DomainEntityAutoComplete<AwardType>
{
    [Parameter]
    public Sport[] Sports { get; set; } = Array.Empty<Sport>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Award Type";
        Placeholder = "Search by award...";
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
            ? AwardType.GetAll(Sports)
            : AwardType.All;
    }
}
