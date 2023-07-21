namespace Memorabilia.Blazor.Controls.TypeAhead;

public class AwardTypeAutoComplete : DomainEntityAutoComplete<AwardType>
{
    [Parameter]
    public bool IncludeMultiSport { get; set; }

    [Parameter]
    public bool IsMultiSport { get; set; }

    [Parameter]
    public Sport[] Sports { get; set; } 
        = Array.Empty<Sport>();

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
        Items = IsMultiSport
            ? AwardType.MultiSport
            : Sports != null &&
              Sports.Any()
                ? AwardType.GetAll(IncludeMultiSport, Sports) 
                : AwardType.All;
    }
}
