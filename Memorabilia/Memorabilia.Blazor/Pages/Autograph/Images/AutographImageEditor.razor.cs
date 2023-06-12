using Memorabilia.Domain.Entities;

namespace Memorabilia.Blazor.Pages.Autograph.Images;

public partial class AutographImageEditor : AutographItem<AutographImagesEditModel>
{
    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }

    private EditImages<AutographImagesEditModel> EditImages;

    protected async Task OnImport()
    {
        var memorabliaImagesViewModel 
            = new MemorabiliaImagesModel(await QueryRouter.Send(new GetMemorabiliaImages(ViewModel.MemorabiliaId)));

        var images = memorabliaImagesViewModel.Images
                                              .Select(image => new Domain.Entities.AutographImage(ViewModel.AutographId,
                                                                                                  image.FileName,
                                                                                                  image.ImageTypeId,
                                                                                                  image.UploadDate))
                                              .ToList();

        ViewModel = new AutographImagesEditModel(images, ViewModel.ItemType, ViewModel.MemorabiliaId, AutographId);
    }

    protected async Task OnLoad()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        ViewModel = new AutographImagesEditModel(autograph.Images, autograph.ItemType, autograph.MemorabiliaId, autograph.Id);
    }

    protected async Task OnSave()
    {
        ViewModel.AutographId = AutographId;
        ViewModel.Images = EditImages.Images;

        await CommandRouter.Send(new SaveAutographImage.Command(ViewModel));
    }

    protected async Task SaveAndAddAutograph()
    {
        await OnSave();

        NavigationManager.NavigateTo(ViewModel.ContinueNavigationPath);
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndAddItem()
    {
        await OnSave();

        NavigationManager.NavigateTo("/Memorabilia/Edit");
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }
}
