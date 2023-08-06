namespace Memorabilia.Blazor.Controls.Labels;

public partial class Text
{
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Class { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public Typo Typography { get; set; }
        = Typo.h3;
}
