namespace Memorabilia.Blazor.Pages.ForTrade;

public partial class EditForTrade
{
    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected List<MemorabiliaModel> SelectedMemorabilia
        = new();

    private MemorabiliaSearchCriteria _filter
        = new();

    private bool _hasItemsForTrade;

    protected override async Task OnInitializedAsync()
    {
        _hasItemsForTrade = await Mediator.Send(new HasItemsForTrade());

        Courier.Subscribe<ForTradeMemorabiliaRemovedNotification>(OnMemorabiliaRemoved);
    }

    protected void OnFilter(MemorabiliaSearchCriteria filter)
    {
        _filter = filter;
    }

    protected async Task AddMemorabilia()
    {
        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<AddForTradeMemorabiliaDialog>(string.Empty,
                                                                      new DialogParameters(),
                                                                      options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        int[] memorabiliaIds
            = items.Select(item => item.Memorabilia.Id)
                   .Distinct()
                   .ToArray();

        await Mediator.Send(new SaveForTradeMemorabilia.Command(addedMemorabiliaIds: memorabiliaIds));

        Snackbar.Add("Items For Trade were saved successfully!", Severity.Success);

        _hasItemsForTrade = true;

        await Mediator.Publish(new ForTradeMemorabiliaAddedNotification());
    }

    protected async Task OnMemorabiliaRemoved(ForTradeMemorabiliaRemovedNotification notification)
    {
        _hasItemsForTrade = await Mediator.Send(new HasItemsForTrade());
    }
}
