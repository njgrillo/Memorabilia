namespace Memorabilia.Blazor.Pages.ThroughTheMail;

public partial class ViewThroughTheMail
{
    [Inject]
    public IMediator Mediator { get; set; }

    private int _receivedItemsCount { get; set; }

    private int _sentItemsCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _receivedItemsCount = await Mediator.Send(new GetReceivedThroughTheMailsCount());
        _sentItemsCount = await Mediator.Send(new GetSentThroughTheMailsCount());

        StateHasChanged();
    }
}
