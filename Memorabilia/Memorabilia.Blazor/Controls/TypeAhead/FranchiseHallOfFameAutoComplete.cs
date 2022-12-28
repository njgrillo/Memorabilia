namespace Memorabilia.Blazor.Controls.TypeAhead;

public class FranchiseHallOfFameAutoComplete : DomainEntityAutoComplete<FranchiseHallOfFameType>
{
    [Parameter]
    public int[] SportIds { get; set; } = Array.Empty<int>();

    private bool _loaded;

    protected override void OnInitialized()
    {
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
        Items = SportIds != null && SportIds.Any() 
            ? FranchiseHallOfFameType.GetAll(SportIds) 
            : FranchiseHallOfFameType.All;
    }
}
