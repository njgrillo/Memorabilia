namespace Memorabilia.Blazor.Controls.TypeAhead;

public class LeaderTypeAutoComplete 
    : DomainEntityAutoComplete<LeaderType>
{
    [Parameter]
    public Sport[] Sports { get; set; } 
        = [];

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
                Sports.Length != 0
            ? LeaderType.GetAll(Sports) 
            : LeaderType.All;
    }
}
