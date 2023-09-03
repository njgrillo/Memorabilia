namespace Memorabilia.Blazor.Pages.ForTrade;

public partial class ForTradeEditor
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected List<MemorabiliaModel> SelectedMemorabilia
        = new();

    private MemorabiliaSearchCriteria _filter
        = new();

    private bool _hasItemsForTrade;

    protected override async Task OnInitializedAsync()
    {
        _hasItemsForTrade = await QueryRouter.Send(new HasItemsForTrade());

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

        await CommandRouter.Send(new SaveForTradeMemorabilia.Command(addedMemorabiliaIds: memorabiliaIds));

        Snackbar.Add("Items For Trade were saved successfully!", Severity.Success);

        _hasItemsForTrade = true;

        await Mediator.Publish(new ForTradeMemorabiliaAddedNotification());
    }

    protected async Task OnMemorabiliaRemoved(ForTradeMemorabiliaRemovedNotification notification)
    {
        _hasItemsForTrade = await QueryRouter.Send(new HasItemsForTrade());
    }
}
