#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class ImageEditor : ComponentBase
{
    [Parameter]
    public bool CanRemove { get; set; }

    [Parameter]
    public string FileName { get; set; }

    [Parameter]
    public bool HasPrimary { get; set; }

    [Parameter]
    public string ImageFilePath { get; set; }

    [Parameter]
    public string ImageRootFilePath { get; set; }

    [Parameter]
    public ImageType ImageType { get; set; }

    [Parameter]
    public bool IsPrimary { get; set; }

    [Parameter]
    public EventCallback<string> OnPrimarySet { get; set; }

    [Parameter]
    public EventCallback<string> OnRemove { get; set; }

    public string Image
    {
        get
        {
            var path = Path.Combine(ImageRootFilePath, ImageFilePath);

            if (path.IsNullOrEmpty() || !File.Exists(path))
                return ImagePath.ImageNotAvailable;

            return $"data:image/jpeg;base64,{Convert.ToBase64String(File.ReadAllBytes(path))}";
        }
    }

    protected async Task Remove(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);

        await OnRemove.InvokeAsync(filePath);
    }

    protected async Task SetPrimary(string filePath)
    {
        await OnPrimarySet.InvokeAsync(filePath);
    }
}
