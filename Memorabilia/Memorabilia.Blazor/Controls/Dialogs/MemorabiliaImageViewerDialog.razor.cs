namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class MemorabiliaImageViewerDialog
{
    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected Domain.Entities.MemorabiliaImage[] Images { get; set; } 
        = Array.Empty<Domain.Entities.MemorabiliaImage>();

    protected Domain.Entities.MemorabiliaImage PrimaryImage
        => Images.Any()
        ? Images.FirstOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)
        : null;

    protected Domain.Entities.MemorabiliaImage SelectedImage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (MemorabiliaId == 0)
            return;

        Images = await QueryRouter.Send(new GetMemorabiliaImagesById(MemorabiliaId));

        if (!Images.Any())
            return;

        SelectedImage = PrimaryImage;
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }
}
