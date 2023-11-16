namespace Memorabilia.Blazor.Controls;

public partial class EditImages<TItem> 
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public ILogger<EditImages<TItem>> Logger { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Parameter]
    public RenderFragment AdditionalButtons { get; set; }

    [Parameter]
    public bool CanImportImages { get; set; }

    [Parameter]
    public string ContinueNavigationPath { get; set; }

    [Parameter]
    public string ExitNavigationPath { get; set; }

    [Parameter]
    public List<ImageEditModel> Images { get; set; }
        = [];

    [Parameter]
    public string ImportButtonText { get; set; }    

    [Parameter]
    public int MaximumAllowedFiles { get; set; }

    [Parameter]
    public long MaximumFileSize { get; set; }

    [Parameter]
    public TItem Model { get; set; }

    [Parameter]
    public EventCallback OnImport { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public string PageTitle { get; set; }

    [Parameter]
    public bool ReplaceImages { get; set; } 
        = true;

    [Parameter]
    public string SaveButtonText { get; set; } 
        = "Save & Continue";

    [Parameter]
    public EventCallback<List<ImageEditModel>> ValueChanged { get; set; }

    private IReadOnlyList<IBrowserFile> _files;

    protected void Cancel()
    {
        foreach (ImageEditModel image in Images.Where(image => image.IsNew))
        {
            ImageService.DeleteImage(Enum.ImageRootType.User, image.FileName);
        }

        Images = []; 

        NavigationManager.NavigateTo(ExitNavigationPath);
    }

    protected async Task SaveAndExit()
    {
        await OnSave.InvokeAsync();

        NavigationManager.NavigateTo(ExitNavigationPath);
        Snackbar.Add("Images were saved successfully!", Severity.Success);
    }

    protected async Task Import()
    {
        await OnImport.InvokeAsync();
    }

    protected async Task LoadFiles(InputFileChangeEventArgs e)
    {
        _files = e.GetMultipleFiles(MaximumAllowedFiles);

        await Save();
    }

    protected void PrimarySet(string fileName)
    {
        ImageEditModel image = Images.FirstOrDefault(i => i.FileName == fileName);

        if (image == null)
            return;

        foreach (ImageEditModel memorabiliaImage in Images)
        {
            if (memorabiliaImage.FileName == image.FileName)
                memorabiliaImage.ImageTypeId = ImageType.Primary.Id;

            if (memorabiliaImage.ImageTypeId == ImageType.Primary.Id && memorabiliaImage.FileName != image.FileName)
                memorabiliaImage.ImageTypeId = ImageType.Secondary.Id;
        }
    }

    protected void Remove(string fileName)
    {
        ImageEditModel image = Images.FirstOrDefault(i => i.FileName == fileName);

        if (image == null)
            return;

        Images.Remove(image);

        if (!image.IsPrimary)
            return;

        ImageEditModel primaryImage = Images.FirstOrDefault();

        if (primaryImage == null)
            return;

        primaryImage.ImageTypeId = ImageType.Primary.Id;
    }

    protected async Task Save()
    {
        var images = new List<ImageEditModel>();

        ImageType imageType = Images.IsNullOrEmpty()
            ? ImageType.Primary 
            : ImageType.Secondary;

        foreach (IBrowserFile file in _files)
        {
            try
            {
                string fileName = await ImageService.LoadFile(file, Enum.ImageRootType.User);

                images.Add(new ImageEditModel(new ImageModel(new Entity.Image(fileName, imageType.Id))));

                imageType = ImageType.Secondary;
            }
            catch (Exception ex)
            {
                Logger.LogError("File: {Filename} Error: {Error}", file.Name, ex.Message);
            }
        }

        if (ReplaceImages)
        {
            Images = images;
        }
        else
        {
            Images.AddRange(images);
        }        
    }
}
