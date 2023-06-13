namespace Memorabilia.Blazor.Controls;

public partial class PageImage
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }
}
