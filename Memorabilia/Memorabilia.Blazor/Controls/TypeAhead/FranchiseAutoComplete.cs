namespace Memorabilia.Blazor.Controls.TypeAhead;

public class FranchiseAutoComplete : DomainEntityAutoComplete<Franchise>
{
    [Parameter]
    public Sport[] Sports { get; set; } 
        = Array.Empty<Sport>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Franchise";
        Placeholder = "Search by franchise...";

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
            ? Franchise.GetAll(Sports)
            : Franchise.All;
    }
}
