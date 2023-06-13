namespace Memorabilia.Blazor.Pages.Autograph.Images;

public partial class AutographImageEditor 
    : AutographItem<AutographImagesEditModel>
{
    [Inject]
    public ISnackbar Snackbar { get; set; }

    private EditImages<AutographImagesEditModel> EditImages;

    protected async Task OnImport()
    {
        var model 
            = new MemorabiliaImagesModel(await QueryRouter.Send(new GetMemorabiliaImages(Model.MemorabiliaId)));

        List<Entity.AutographImage> images 
            = model.Images
                   .Select(image => new Entity.AutographImage(Model.AutographId,
                                                              image.FileName,
                                                              image.ImageTypeId,
                                                              image.UploadDate))
                   .ToList();

        Model = new AutographImagesEditModel(images, 
                                             Model.ItemType,
                                             Model.MemorabiliaId, 
                                             AutographId);
    }

    protected async Task OnLoad()
    {
        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        Model = new AutographImagesEditModel(autograph.Images, 
                                             autograph.ItemType, 
                                             autograph.MemorabiliaId, 
                                             autograph.Id);
    }

    protected async Task OnSave()
    {
        Model.AutographId = AutographId;
        Model.Images = EditImages.Images;

        await CommandRouter.Send(new SaveAutographImage.Command(Model));
    }

    protected async Task SaveAndAddAutograph()
    {
        await OnSave();

        NavigationManager.NavigateTo(Model.ContinueNavigationPath);
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndAddItem()
    {
        await OnSave();

        NavigationManager.NavigateTo("/Memorabilia/Edit");
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }
}
