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
    public string Class { get; set; }
        = "rounded-lg ";

    [Parameter]
    public int Elevation { get; set; }
        = 5;

    [Parameter]
    public int? Height { get; set; }
        = 200;

    [Parameter]
    public string ImageData { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public EventCallback ImageLoaded { get; set; }

    [Parameter]
    public string NavigationPath { get; set; }

    [Parameter]
    public ObjectFit ObjectFit { get; set; }
        = ObjectFit.Cover;

    [Parameter]
    public EventCallback OnClick { get; set; }    

    [Parameter]
    public string TooltipText { get; set; }

    [Parameter]
    public int? UserId { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;

    [Parameter]
    public int? Width { get; set; }
        = 200;    

    protected override void OnInitialized()
    {
        Class += AllowNavigation
            ? "can-click"
            : "cant-click";
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (!ImageData.IsNullOrEmpty() || 
            ImageFileName.IsNullOrEmpty())
            return;

        ImageData = ImageService.GetUserImageData(ImageFileName, UserId);

        await ImageLoaded.InvokeAsync();
    }

    protected virtual async Task OnImageClick()
    {
        if (!AllowNavigation)
            return;

        if (NavigationPath.IsNullOrEmpty())
        {
            await OnClick.InvokeAsync();
            return;
        }

        NavigationManager.NavigateTo(NavigationPath);         
    }    
}
