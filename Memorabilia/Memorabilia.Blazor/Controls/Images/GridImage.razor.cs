namespace Memorabilia.Blazor.Controls.Images;

public partial class GridImage
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public EventCallback ImageLoaded { get; set; }

    [Parameter]
    public string NavigationPath { get; set; }

    protected string ImageData { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!ImageData.IsNullOrEmpty() || 
            ImageFileName.IsNullOrEmpty())
            return;

        ImageData = ImageService.GetUserImageData(ImageFileName);

        await ImageLoaded.InvokeAsync();
    }
}
