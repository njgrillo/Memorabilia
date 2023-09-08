namespace Memorabilia.Blazor.Controls;

public partial class PageView
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string AddRoute { get; set; }

    [Parameter]
    public string AddTitle { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public bool DisplayAddButton { get; set; } 
        = true;

    [Parameter]
    public bool DisplayPageFooter { get; set; }
        = true;

    [Parameter]
    public bool DisplayPageHeader { get; set; } 
        = true;

    [Parameter]
    public string NavigationPath { get; set; }

    [Parameter]
    public string NavigationPathText { get; set; } 
        = "Back";

    [Parameter]
    public string PageTitle { get; set; }
}
