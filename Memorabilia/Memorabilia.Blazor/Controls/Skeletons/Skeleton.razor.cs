namespace Memorabilia.Blazor.Controls.Skeletons;

public partial class Skeleton
{
    [Parameter]
    public string Height { get; set; }

    [Parameter]
    public SkeletonType Type { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
