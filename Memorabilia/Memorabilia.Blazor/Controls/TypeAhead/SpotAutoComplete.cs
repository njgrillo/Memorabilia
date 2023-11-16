namespace Memorabilia.Blazor.Controls.TypeAhead;

public class SpotAutoComplete : DomainEntityAutoComplete<Spot>
{
    [Parameter]
    public Spot[] Spots { get; set; } 
        = [];

    private bool _loaded;

    protected override void OnInitialized()
    {
        AdornmentIcon = string.Empty;
        Label = "Spot";
        Placeholder = "Search by Spot...";

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
        Items = Spots.HasAny()
            ? Spots
            : Spot.All;
    }
}
