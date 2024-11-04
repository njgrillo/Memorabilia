namespace Memorabilia.Blazor.Controls.Links;

public partial class ExpandableLink
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string ExpandText { get; set; }

    private bool _isExpanded; 

    private void OnExpand()
    {
        _isExpanded = true;
    }
}
