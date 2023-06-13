namespace Memorabilia.Blazor.Controls;

public partial class ImageEditor
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public bool CanRemove { get; set; }

    [Parameter]
    public bool HasPrimary { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public Enum.ImageRootType ImageRootType { get; set; }

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
        ImageService.DeleteImage(ImageRootType, imageFileName);

        await OnRemove.InvokeAsync(imageFileName);
    }

    protected async Task SetPrimary(string imageFileName)
    {
        await OnPrimarySet.InvokeAsync(imageFileName);
    }
}
