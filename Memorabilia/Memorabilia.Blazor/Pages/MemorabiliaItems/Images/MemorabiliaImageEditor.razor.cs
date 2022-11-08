#nullable disable

namespace Memorabilia.Blazor.Pages.MemorabiliaItems.Images;

public partial class MemorabiliaImageEditor : ImagePage
{
    [Parameter]
    public int MemorabiliaId { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private EditImages<SaveMemorabiliaImagesViewModel> EditImages;
    private SaveMemorabiliaImagesViewModel ViewModel = new ();

    protected async Task OnLoad()
    {
        var memorabilia = await QueryRouter.Send(new GetMemorabiliaItem(MemorabiliaId));

        ViewModel = new SaveMemorabiliaImagesViewModel(memorabilia.Images, memorabilia.ItemTypeName)
        {
            MemorabiliaId = MemorabiliaId
        };
    }

    protected async Task OnSave()
    {
        ViewModel.Images = EditImages.Images;            

        await CommandRouter.Send(new SaveMemorabiliaImage.Command(ViewModel));
    }
}
