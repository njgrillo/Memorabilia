namespace Memorabilia.Blazor.Controls;

public partial class PageHeader
{
    [Parameter]
    public string PageTitle { get; set; }

    [Parameter]
    public string Style { get; set; }

    [Parameter]
    public bool Visible { get; set; }
        = true;
}
