namespace Memorabilia.Blazor.Controls.TypeAhead;

public class FranchiseHallOfFameAutoComplete 
    : DomainEntityAutoComplete<FranchiseHallOfFameType>
{
    [Parameter]
    public Sport[] Sports { get; set; } 
        = [];

    private bool _loaded;

    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Franchise Hall of Fame";
        Placeholder = "Search by franchise...";
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
            ? FranchiseHallOfFameType.GetAll(Sports) 
            : FranchiseHallOfFameType.All;
    }
}
