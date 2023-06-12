namespace Memorabilia.Blazor.Controls;

public partial class ImageEditor
{
    [Parameter]
    public bool CanRemove { get; set; }

    [Parameter]
    public bool HasPrimary { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public string ImageRootPath { get; set; }

    [Parameter]
    public ImageType ImageType { get; set; }

    [Parameter]
    public bool IsPrimary { get; set; }

    [Parameter]
    public EventCallback<string> OnPrimarySet { get; set; }

    [Parameter]
    public EventCallback<string> OnRemove { get; set; }

    protected async Task Remove(string imageFileName)
    {
        string imageFilePath = Path.Combine(ImageRootPath, imageFileName);

        if (File.Exists(imageFilePath))
            File.Delete(imageFilePath);

        await OnRemove.InvokeAsync(imageFileName);
    }

    protected async Task SetPrimary(string imageFileName)
    {
        await OnPrimarySet.InvokeAsync(imageFileName);
    }
}
