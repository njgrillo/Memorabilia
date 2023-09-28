﻿namespace Memorabilia.Blazor.Pages.SignatureReview;

public partial class ViewSignatureReviews
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public IDialogService DialogService { get; set; }

    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    protected SignatureReviewsModel Model
        = new();

    private bool _resetPaging;

    private MudTable<SignatureReviewModel> _table
       = new();

    protected override async Task OnInitializedAsync()
    {
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

        Model = await QueryRouter.Send(new GetSignatureReviews(pageInfo));

        return new TableData<SignatureReviewModel>()
        {
            Items = Model.SignatureReviews,
            TotalItems = Model.PageInfo.TotalItems
        };
    }

    protected async Task Random()
    {
        Entity.SignatureReview signatureReview
            = await QueryRouter.Send(new GetRandomSignatureReview());

        NavigationManager.NavigateTo($"{NavigationPath.SignatureReview}/{DataProtectorService.EncryptId(signatureReview.Id)}");
    }

    private void ToggleChildContent(int signatureReviewId)
    {
        SignatureReviewModel signatureReview
            = Model.SignatureReviews.Single(item => item.Id == signatureReviewId);

        signatureReview.DisplayDetails = !signatureReview.DisplayDetails;
        signatureReview.ToggleIcon = signatureReview.DisplayDetails
            ? Icons.Material.Filled.ExpandLess
            : Icons.Material.Filled.ExpandMore;
    }
}
