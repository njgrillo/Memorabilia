namespace Memorabilia.Blazor.Controls.Dialogs;

public partial class AutographImageViewerDialog
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [CascadingParameter]
    public MudDialogInstance MudDialog { get; set; }

    [Parameter]
    public int AutographId { get; set; }

    [Parameter]
    public int UserId { get; set; }

    protected Domain.Entities.AutographImage[] Images { get; set; } 
        = Array.Empty<Domain.Entities.AutographImage>();

    protected Domain.Entities.AutographImage PrimaryImage
        => Images.Any()
        ? Images.FirstOrDefault(image => image.ImageTypeId == ImageType.Primary.Id)
        : null;

    protected Domain.Entities.AutographImage SelectedImage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (AutographId == 0)
            return;

        Images = await QueryRouter.Send(new GetAutographImagesById(AutographId));

        if (!Images.Any())
            return;

        SelectedImage = PrimaryImage;
    }

    public void Cancel()
    {
        MudDialog.Cancel();
    }
}
