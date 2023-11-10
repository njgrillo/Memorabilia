namespace Memorabilia.Blazor.Pages.SignatureReview;

public partial class SignatureReviewImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int SelectedImageId { get; set; }

    [Parameter]
    public int SignatureReviewId { get; set; }

    protected SignatureReviewImageModel[] Images { get; set; }
        = Array.Empty<SignatureReviewImageModel>();

    protected override async Task OnInitializedAsync()
    {
        if (SignatureReviewId == 0)
            return;

        Entity.SignatureReview signatureReview
            = await Mediator.Send(new GetSignatureReview(SignatureReviewId));

        Images = signatureReview.Images
                                .Select(image => new SignatureReviewImageModel(image))
                                .ToArray();
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
