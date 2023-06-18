namespace Memorabilia.Blazor.Controls;

public partial class PageLoader
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool IsLoading { get; set; }
}
