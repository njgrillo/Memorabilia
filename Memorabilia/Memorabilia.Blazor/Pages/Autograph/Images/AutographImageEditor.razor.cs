namespace Memorabilia.Blazor.Pages.Autograph.Images;

public partial class AutographImageEditor 
    : AutographItem<AutographImagesEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    private EditImages<AutographImagesEditModel> EditImages;

    protected override async Task OnInitializedAsync()
    {
        AutographId = DataProtectorService.DecryptId(EncryptAutographId);

        var autograph = new AutographModel(await QueryRouter.Send(new GetAutograph(AutographId)));

        Model = new AutographImagesEditModel(autograph.Images,
                                             autograph.ItemType,
                                             autograph.MemorabiliaId,
                                             autograph.Id);

        Model.BackNavigationPath =
            Model.CanHaveSpot
                ? $"Autographs/{AdminDomainItem.Spots.Item}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}"
                : $"Autographs/Authentications/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}";

        IsLoaded = true;
    }

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

    protected async Task OnSave()
    {
        Model.AutographId = AutographId;
        Model.Images = EditImages.Images;

        await CommandRouter.Send(new SaveAutographImage.Command(Model));
    }

    protected async Task SaveAndAddAutograph()
    {
        await OnSave();

        Model.ContinueNavigationPath 
            = $"Autographs/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(Model.MemorabiliaId)}/{DataProtectorService.EncryptId(-1)}";

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
