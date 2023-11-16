using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.SignatureReview;

public partial class ViewSignatureReviews : ReroutePage
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [Parameter]
    public bool DisplayReviewGridButton { get; set; }
        = true;

    [Parameter]
    public bool DisplayReviewRandomButton { get; set; }
        = true;

    [Parameter]
    public bool FilterByUser { get; set; }
        = false;

    protected SignatureReviewsModel Model
        = new();

    private bool _canInteract;
    private bool _resetPaging;

    private MudTable<SignatureReviewModel> _table
       = new();

    protected override async Task OnInitializedAsync()
    {
        _canInteract 
            = ApplicationStateService.CurrentUser != null &&
              ApplicationStateService.CurrentUser.HasPermission(Permission.EditSignatureAuthentication);

        _resetPaging = true;

        await _table.ReloadServerData();

        _resetPaging = false;
    }

    protected async Task OnImageClick(SignatureReviewModel signatureReview)
    {
        var parameters = new DialogParameters
        {
            ["SignatureReviewId"] = signatureReview.Id
        };

        var options = new DialogOptions()
        {
            MaxWidth = MaxWidth.Small,
            DisableBackdropClick = true
        };

        var dialog = DialogService.Show<SignatureReviewImageCarouselViewerDialog>(string.Empty, parameters, options);

        await dialog.Result;
    }

    protected async Task<TableData<SignatureReviewModel>> OnRead(TableState state)
    {
        var pageInfo = new PageInfo(_resetPaging ? 1 : state.Page + 1, state.PageSize);

        Model = await Mediator.Send(new GetSignatureReviews(pageInfo, FilterByUser));

        return new TableData<SignatureReviewModel>()
        {
            Items = Model.SignatureReviews,
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

        Entity.SignatureReview signatureReview
            = await Mediator.Send(new GetRandomSignatureReview());

        NavigationManager.NavigateTo($"{NavigationPath.SignatureReview}/{DataProtectorService.EncryptId(signatureReview.Id)}");
    }

    private void ToggleChildContent(int signatureReviewId)
    {
        SignatureReviewModel signatureReview
            = Model.SignatureReviews.Single(item => item.Id == signatureReviewId);

        signatureReview.DisplayDetails = !signatureReview.DisplayDetails;
    }

    private async Task View(int signatureReviewId)
    {
        if (!_canInteract)
        {
            await ShowMembershipDialog();
            return;
        }

        NavigationManager.NavigateTo($"{NavigationPath.SignatureReview}/{DataProtectorService.EncryptId(signatureReviewId)}");
    }
}
