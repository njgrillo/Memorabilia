namespace Memorabilia.Blazor.Controls;

public partial class SkeletonLoader
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Height { get; set; }
        = "50px";

    [Parameter]
    public bool IsLoading { get; set; }

    [Parameter]
    public SkeletonType SkeletonType { get; set; }
        = SkeletonType.Rectangle;
}
