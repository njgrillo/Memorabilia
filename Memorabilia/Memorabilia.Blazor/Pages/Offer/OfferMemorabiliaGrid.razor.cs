namespace Memorabilia.Blazor.Pages.Offer;

public partial class OfferMemorabiliaGrid
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public bool ReadOnly { get; set; }

    [Parameter]
    public OfferMemorabiliaModel Item { get; set; }

    protected List<OfferMemorabiliaModel> Items
        = [];

    protected override void OnParametersSet()
    {
        if (Item == null)
            return;

        Items = [Item];
    }

    private void ToggleChildContent(int memorabiliaItemId)
    {
        OfferMemorabiliaModel memorabiliaItem
            = Items.Single(item => item.MemorabiliaId == memorabiliaItemId);

        memorabiliaItem.DisplayAutographDetails = !memorabiliaItem.DisplayAutographDetails;
    }
}
