namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public IMediator Mediator { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public int? UserId { get; set; }

    protected Entity.MemorabiliaImage[] Images { get; set; }
        = [];

    protected override async Task OnInitializedAsync()
    {
        if (MemorabiliaId == 0)
            return;

        Images = await Mediator.Send(new GetMemorabiliaImages(MemorabiliaId));
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
