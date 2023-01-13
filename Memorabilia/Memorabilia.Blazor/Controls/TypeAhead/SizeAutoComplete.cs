namespace Memorabilia.Blazor.Controls.TypeAhead;

public class SizeAutoComplete : DomainEntityAutoComplete<Domain.Constants.Size>
{
    [Parameter]
    public Domain.Constants.Size[] Sizes { get; set; } = Array.Empty<Domain.Constants.Size>();

    private bool _loaded;

    protected override void OnInitialized()
    {
        Label = "Size";
        Placeholder = "Search by Size...";

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
        Items = Sizes != null && Sizes.Any()
            ? Sizes
            : Domain.Constants.Size.All;
    }
}
