namespace Memorabilia.Blazor.Controls.Images;

public partial class GridImage
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public bool AllowNavigation { get; set; }
        = true;    

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public EventCallback ImageLoaded { get; set; }

    [Parameter]
    public bool IsPersonImage { get; set; }

    [Parameter]
    public string NavigationPath { get; set; }

    [Parameter]
    public int? UserId { get; set; }

    protected string ImageData { get; set; }

    private string _imageClass = "rounded-lg ";

    protected override void OnInitialized()
    {
        _imageClass += AllowNavigation
            ? "can-click"
            : "cant-click";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!ImageData.IsNullOrEmpty() || 
            ImageFileName.IsNullOrEmpty())
            return;

        ImageData = IsPersonImage
            ? ImageService.GetPersonImageData(ImageFileName)    
            : ImageService.GetUserImageData(ImageFileName, UserId);

        await ImageLoaded.InvokeAsync();
    }

    protected void OnImageClick()
    {
        if (!AllowNavigation)
            return;

        NavigationManager.NavigateTo(NavigationPath);
    }
}
