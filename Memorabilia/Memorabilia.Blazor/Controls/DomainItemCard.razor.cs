namespace Memorabilia.Blazor.Controls;

public partial class DomainItemCard
{
    [Inject]
    public ImageService ImageService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string Description { get; set; }

    [Parameter]
    public string ImageFileName { get; set; }

    [Parameter]
    public string Page { get; set; }

    [Parameter]
    public string Title { get; set; }

    protected void OnClick()
    {
        NavigationManager.NavigateTo(Page);
    }
}
