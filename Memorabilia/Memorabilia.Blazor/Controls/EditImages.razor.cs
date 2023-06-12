﻿namespace Memorabilia.Blazor.Controls;

public partial class EditImages<TItem> 
{
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
    public string ImageRootPath { get; set; }

    [Parameter]
    public List<ImageEditModel> Images { get; set; }
        = new();

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
    public string SaveButtonText { get; set; } 
        = "Save & Continue";

    [Parameter]
    public string UploadPath { get; set; }

    [Parameter]
    public int UserId { get; set; }

    [Parameter]
    public EventCallback<List<ImageEditModel>> ValueChanged { get; set; }

    private IReadOnlyList<IBrowserFile> _files;

    protected void Cancel()
    {
        foreach (ImageEditModel image in Images.Where(image => image.IsNew))
        {
            string filePath = Path.Combine(ImageRootPath, image.FileName);

            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        Images = new List<ImageEditModel>();

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

        ImageType imageType = !Images.Any() 
            ? ImageType.Primary 
            : ImageType.Secondary;

        if (!Directory.Exists(UploadPath))
            Directory.CreateDirectory(UploadPath);

        foreach (IBrowserFile file in _files)
        {
            try
            {   
                string fileName = Path.GetRandomFileName();
                string path = Path.Combine(UploadPath, fileName);

                await using FileStream fs = new(path, FileMode.Create);
                await file.OpenReadStream(MaximumFileSize).CopyToAsync(fs);

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
