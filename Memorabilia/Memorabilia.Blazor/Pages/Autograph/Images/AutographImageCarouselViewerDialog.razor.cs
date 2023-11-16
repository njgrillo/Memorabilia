namespace Memorabilia.Blazor.Pages.Autograph.Images;

public partial class AutographImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    [Parameter]
    public int? UserId { get; set; }

    protected Entity.AutographImage[] Images { get; set; }
        = [];

    protected override async Task OnInitializedAsync()
    {
        if (AutographId == 0)
            return;

        Images = await Mediator.Send(new GetAutographImages(AutographId));
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
