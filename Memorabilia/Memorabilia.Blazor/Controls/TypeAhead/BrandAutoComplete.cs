namespace Memorabilia.Blazor.Controls.TypeAhead;

public class BrandAutoComplete : DomainEntityAutoComplete<Brand>
{
    [Parameter]
    public Brand[] Brands { get; set; } = Array.Empty<Brand>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Brand";
        Placeholder = "Search by Brand...";

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
        Items = Brands != null && Brands.Any()
            ? Brands
            : Brand.All;
    }
}
