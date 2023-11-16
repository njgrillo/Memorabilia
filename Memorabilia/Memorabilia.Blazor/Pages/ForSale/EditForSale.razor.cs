using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.ForSale;

public partial class EditForSale
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public ICourier Courier { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    protected List<MemorabiliaModel> SelectedMemorabilia
        = [];

    private MemorabiliaSearchCriteria _filter
        = new();

    private bool _hasItemsForSale;

    protected override async Task OnInitializedAsync()
    {
        _hasItemsForSale = await Mediator.Send(new HasItemsForSale());

        Courier.Subscribe<ForSaleMemorabiliaRemovedNotification>(OnMemorabiliaRemoved);
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

        var dialog = DialogService.Show<AddForSaleMemorabiliaDialog>(string.Empty,
                                                                     [],
                                                                     options);
        var result = await dialog.Result;

        if (result.Canceled)
            return;

        var items = (List<MemorabiliaModel>)result.Data;

        List<ForSaleMemorabiliaEditModel> forSaleMemorabilias
            = items.Select(item => new ForSaleMemorabiliaEditModel
            {
                ItemTypeName = item.ItemTypeName,
                MemorabiliaId = item.Id,
                MemorabiliaPrimaryImage = item.ImageFileName
            }).ToList();

        ForSaleEditModel editModel = new()
        {
            Items = forSaleMemorabilias
        };

        await Mediator.Send(new SaveForSaleMemorabilia.Command(editModel));

        Snackbar.Add("Items For Sale were added successfully!", Severity.Success);

        _hasItemsForSale = true;

        await Mediator.Publish(new ForSaleMemorabiliaAddedNotification());
    }

    protected async Task OnMemorabiliaRemoved(ForSaleMemorabiliaRemovedNotification notification)
    {
        _hasItemsForSale = await Mediator.Send(new HasItemsForSale());
    }
}
