#nullable disable

using Memorabilia.Blazor.Controls;

namespace Memorabilia.Blazor.Pages.Autograph.Images;

public partial class AutographImageEditor : AutographItem<SaveAutographImagesViewModel>
{
    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private EditImages<SaveAutographImagesViewModel> EditImages;

    protected async Task OnImportClick()
    {
        var query = new GetMemorabiliaImages.Query(ViewModel.MemorabiliaId);
        var memorabliaImagesViewModel = await QueryRouter.Send(query);
        var images = memorabliaImagesViewModel.Images
                                              .Select(image => new Domain.Entities.AutographImage(ViewModel.AutographId,
                                                                                                  image.FilePath,
                                                                                                  image.ImageTypeId,
                                                                                                  image.UploadDate))
                                              .ToList();

        ViewModel = new SaveAutographImagesViewModel(images, ViewModel.ItemType, ViewModel.MemorabiliaId, AutographId);
    }

    protected async Task OnLoad()
    {
        var autograph = await QueryRouter.Send(new GetAutograph.Query(AutographId));

        ViewModel = new SaveAutographImagesViewModel(autograph.Images, autograph.ItemType, autograph.MemorabiliaId, autograph.Id);
    }

    protected async Task OnSave()
    {
        ViewModel.AutographId = AutographId;
        ViewModel.Images = EditImages.Images;

        await CommandRouter.Send(new SaveAutographImage.Command(ViewModel));
    }
}
