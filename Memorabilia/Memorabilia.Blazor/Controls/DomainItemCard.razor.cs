#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class DomainItemCard : ImagePage
{
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
