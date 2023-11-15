namespace Memorabilia.Blazor.Controls.NavigationMenu;

public partial class NavigationGroup
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Icon { get; set; }

    [Parameter]
    public string Title { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
