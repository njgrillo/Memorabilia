namespace Memorabilia.Blazor.Pages.User;

public partial class SubscriberLevel
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public Feature[] Features { get; set; }

    [Parameter]
    public EventCallback OnSelect { get; set; }

    [Parameter]
    public decimal? SubscriptionPrice { get; set; }

    [Parameter]
    public string Title { get; set; }

    private string _price
        => SubscriptionPrice.HasValue
            ? $" - {SubscriptionPrice.Value:c}"
            : string.Empty;

    protected async Task Select()
    {
        await OnSelect.InvokeAsync();
    }

    protected void ShowDescription(Feature feature)
    {

    }
}
