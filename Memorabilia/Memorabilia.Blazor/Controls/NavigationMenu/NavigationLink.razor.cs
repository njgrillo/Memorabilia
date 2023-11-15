namespace Memorabilia.Blazor.Controls.NavigationMenu;

public partial class NavigationLink
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Href { get; set; }

    [Parameter]
    public string Icon { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
