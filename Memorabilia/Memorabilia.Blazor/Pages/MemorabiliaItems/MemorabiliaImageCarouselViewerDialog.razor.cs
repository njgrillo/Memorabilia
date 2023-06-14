namespace Memorabilia.Blazor.Pages.MemorabiliaItems;

public partial class MemorabiliaImageCarouselViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    protected Entity.MemorabiliaImage[] Images { get; set; }
        = Array.Empty<Entity.MemorabiliaImage>();

    protected override async Task OnInitializedAsync()
    {
        if (MemorabiliaId == 0)
            return;

        Images = await QueryRouter.Send(new GetMemorabiliaImages(MemorabiliaId));
    }

    public void Close()
    {
        MudDialog.Cancel();
    }
}
