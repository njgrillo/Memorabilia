namespace Memorabilia.Blazor.Controls.Labels;

public partial class Header
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Text { get; set; }
}
