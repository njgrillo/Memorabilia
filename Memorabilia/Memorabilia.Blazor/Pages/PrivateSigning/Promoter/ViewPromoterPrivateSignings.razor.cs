namespace Memorabilia.Blazor.Pages.PrivateSigning.Promoter;

public partial class ViewPromoterPrivateSignings
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }

    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected PromoterPrivateSigningsModel Model { get; set; }
        = new();

    private bool _resetPaging;

    private MudTable<PromoterPrivateSigningModel> _table
       = new();

    protected override async Task OnInitializedAsync()
    {
        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected void AddPrivateSigning()
    {
        NavigationManager.NavigateTo(NavigationPath.MyPrivateSigningsEdit);
    }

    private async Task OnPromoterImageClick(string imageFileName)
    {
        var parameters = new DialogParameters
        {
            ["ImageFileName"] = imageFileName,
            ["UserId"] = ApplicationStateService.CurrentUser.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.ExtraLarge,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImageDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    protected async Task<TableData<PromoterPrivateSigningModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetPromoterPrivateSignings(pageInfo));

        return new TableData<PromoterPrivateSigningModel>()
        {
            Items = Model.PrivateSignings,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    private void ToggleChildContent(int privateSigningId)
    {
        PromoterPrivateSigningModel privateSigning
            = Model.PrivateSignings.Single(item => item.Id == privateSigningId);

        privateSigning.DisplayDetails = !privateSigning.DisplayDetails;
    }
}
