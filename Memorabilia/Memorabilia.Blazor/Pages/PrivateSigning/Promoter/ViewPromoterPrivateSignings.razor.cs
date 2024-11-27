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

    [Inject]
    public ISnackbar Snackbar { get; set; }

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

    protected async Task Delete(int id)
    {
        PromoterPrivateSigningModel deletedItem = Model.PrivateSignings.Single(item => item.Id == id);

        var editModel = new PrivateSigningEditModel(deletedItem.Id);

        editModel.Delete();

        await Mediator.Send(new SavePrivateSigning.Command(editModel));

        Model.PrivateSignings.Remove(deletedItem);

        Snackbar.Add("Private Signing was deleted successfully!", Severity.Success);
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
            MaxWidth = MaxWidth.Medium,
            FullWidth = true,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<ImageDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    private async Task OnPublishClick(int id)
    {
        var dialog = DialogService.Show<PublishDialog>();
        var result = await dialog.Result;

        if (result.Canceled)
            return;        

        await Mediator.Send(new PublishPrivateSigning(id));

        Snackbar.Add("Private Signing was published successfully!", Severity.Success);

        await _table.ReloadServerData();
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
