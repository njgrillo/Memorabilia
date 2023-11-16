using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.SignatureIdentification;

public partial class ViewSignatureIdentifications : ReroutePage
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public bool DisplayIdentifyGridButton { get; set; }
        = true;

    [Parameter]
    public bool DisplayIdentifyRandomButton { get; set; }
        = true;

    [Parameter]
    public bool FilterByUser { get; set; }
        = false;

    protected SignatureIdentificationsModel Model
        = new();

    private bool _canInteract;
    private bool _resetPaging;

    private MudTable<SignatureIdentificationModel> _table
       = new();

    protected override async Task OnInitializedAsync()
    {
        _canInteract
            = ApplicationStateService.CurrentUser != null &&
              ApplicationStateService.CurrentUser.HasPermission(Permission.EditSignatureIdentification);

        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task OnImageClick(SignatureIdentificationModel signatureIdentification)
    {
        var parameters = new DialogParameters
        {
            ["SignatureIdentificationId"] = signatureIdentification.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SignatureIdentificationImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    protected async Task<TableData<SignatureIdentificationModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetSignatureIdentifications(pageInfo, FilterByUser));

        return new TableData<SignatureIdentificationModel>()
        {
            Items = Model.SignatureIdentifications,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task Random()
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        Entity.SignatureIdentification signatureIdentification 
            = await Mediator.Send(new GetRandomSignatureIdentfication());

        NavigationManager.NavigateTo($"{NavigationPath.SignatureIdentification}/{DataProtectorService.EncryptId(signatureIdentification.Id)}");
    }

    private void ToggleChildContent(int signatureIdentificationId)
    {
        SignatureIdentificationModel signatureIdentification 
            = Model.SignatureIdentifications.Single(item => item.Id == signatureIdentificationId);

        signatureIdentification.DisplayDetails = !signatureIdentification.DisplayDetails;
    }

    private async Task View(int signatureIdentificationId)
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        NavigationManager.NavigateTo($"{NavigationPath.SignatureIdentification}/{DataProtectorService.EncryptId(signatureIdentificationId)}");
    }
}
