namespace Memorabilia.Blazor.Controls;

public partial class EditImages<TItem> : ImagePage
{
    [Inject]
    public ILogger<EditImages<TItem>> Logger { get; set; }

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
    public List<SaveImageViewModel> Images { get; set; } = new();

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
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public EventCallback OnSave { get; set; }

    [Parameter]
    public string PageTitle { get; set; }

    [Parameter]
    public bool ReplaceImages { get; set; } = true;

    [Parameter]
    public string SaveButtonText { get; set; } = "Save & Continue";

    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }

    [Parameter]
    public EventCallback<List<SaveImageViewModel>> ValueChanged { get; set; }

    private IReadOnlyList<IBrowserFile> _files;

    protected void Cancel()
    {
        foreach (var image in Images.Where(image => image.IsNew))
        {
            var filePath = Path.Combine(ImageRootPath, image.FileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        Images = new List<SaveImageViewModel>();

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
        var image = Images.FirstOrDefault(i => i.FileName == fileName);

        if (image == null)
            return;

        foreach (var memorabiliaImage in Images)
        {
            if (memorabiliaImage.FileName == image.FileName)
                memorabiliaImage.ImageTypeId = ImageType.Primary.Id;

            if (memorabiliaImage.ImageTypeId == ImageType.Primary.Id && memorabiliaImage.FileName != image.FileName)
                memorabiliaImage.ImageTypeId = ImageType.Secondary.Id;
        }
    }

    protected void Remove(string fileName)
    {
        var image = Images.FirstOrDefault(i => i.FileName == fileName);

        if (image == null)
            return;

        Images.Remove(image);

        if (!image.IsPrimary)
            return;

        var primaryImage = Images.FirstOrDefault();

        if (primaryImage == null)
            return;

        primaryImage.ImageTypeId = ImageType.Primary.Id;
    }

    protected async Task Save()
    {
        var images = new List<SaveImageViewModel>();
        var imageType = !Images.Any() ? ImageType.Primary : ImageType.Secondary;

        if (!Directory.Exists(UploadPath))
            Directory.CreateDirectory(UploadPath);

        foreach (var file in _files)
        {
            try
            {   
                var fileName = Path.GetRandomFileName();
                var path = Path.Combine(UploadPath, fileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(MaximumFileSize).CopyToAsync(fs);

                images.Add(new SaveImageViewModel(new ImageViewModel(new Domain.Entities.Image(fileName, imageType.Id))));

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
