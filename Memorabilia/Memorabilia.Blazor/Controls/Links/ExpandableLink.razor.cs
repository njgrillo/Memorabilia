namespace Memorabilia.Blazor.Controls.Links;

public partial class ExpandableLink
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string ExpandText { get; set; }

    [Parameter]
    public bool IsExpanded { get; set; }

    private void OnExpand()
    {
        IsExpanded = true;
    }
}
