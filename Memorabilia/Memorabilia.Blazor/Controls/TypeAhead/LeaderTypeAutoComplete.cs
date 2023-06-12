namespace Memorabilia.Blazor.Controls.TypeAhead;

public class LeaderTypeAutoComplete 
    : DomainEntityAutoComplete<LeaderType>
{
    [Parameter]
    public Sport[] Sports { get; set; } 
        = Array.Empty<Sport>();

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
        Items = Sports != null && 
                Sports.Any() 
            ? LeaderType.GetAll(Sports) 
            : LeaderType.All;
    }
}
