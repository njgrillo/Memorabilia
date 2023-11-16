using Memorabilia.Application.Services.Interfaces;

namespace Memorabilia.Blazor.Pages.Autograph.Images;

public partial class EditAutographImage
    : AutographItem<AutographImagesEditModel>
{
    [Inject]
    public IDataProtectorService DataProtectorService { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public string EncryptAutographId { get; set; }

    private EditImages<AutographImagesEditModel> EditImages;

    private string _backNavigationPath;
    private string _continueNavigationPath;

    protected override async Task OnInitializedAsync()
    {
        AutographId = DataProtectorService.DecryptId(EncryptAutographId);

        var autograph = new AutographModel(await Mediator.Send(new GetAutograph(AutographId)));

        Model = new AutographImagesEditModel(autograph.Images,
                                             autograph.ItemType,
                                             autograph.MemorabiliaId,
                                             autograph.Id);

        _backNavigationPath =
            Model.CanHaveSpot
                ? $"{NavigationPath.Autographs}/{AdminDomainItem.Spots.Item}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}"
                : $"{NavigationPath.Authentications}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(AutographId)}";

        IsLoaded = true;
    }

    protected string GetPageTitle()
        => $"{(Model.EditModeType == EditModeType.Add
                ? EditModeType.Add.Name
                : EditModeType.Update.Name)} Image(s)";

    protected async Task OnImport()
    {
        var model 
            = new MemorabiliaImagesModel(await Mediator.Send(new GetMemorabiliaImages(Model.MemorabiliaId)));

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

        await Mediator.Send(new SaveAutographImage.Command(Model));
    }

    protected async Task SaveAndAddAutograph()
    {
        await OnSave();

        _continueNavigationPath
            = $"{NavigationPath.Autographs}/{EditModeType.Update.Name}/{DataProtectorService.EncryptId(Model.MemorabiliaId)}/{DataProtectorService.EncryptId(-1)}";

        NavigationManager.NavigateTo(_continueNavigationPath);

        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task SaveAndAddItem()
    {
        await OnSave();

        NavigationManager.NavigateTo($"/{NavigationPath.Memorabilia}/{EditModeType.Update.Name}");
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }
}
