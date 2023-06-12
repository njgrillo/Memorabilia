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

    [Parameter]
    public int UserId { get; set; }

    protected string ImageData { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!ImageData.IsNullOrEmpty() || 
            ImageFileName.IsNullOrEmpty() || 
            UserId == 0)
            return;

        ImageData = ImageService.GetUserImageData(ImageFileName, UserId);

        await ImageLoaded.InvokeAsync();
    }
}
