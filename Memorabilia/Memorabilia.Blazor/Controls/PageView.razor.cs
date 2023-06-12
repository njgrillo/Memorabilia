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
    public RenderFragment Content { get; set; }

    [Parameter]
    public bool DisplayAddButton { get; set; } 
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
    public EventCallback OnLoad { get; set; }

    [Parameter]
    public string PageTitle { get; set; }

    [Parameter]
    public int UserId { get; set; }

    public async Task Load()
    {
        await OnLoad.InvokeAsync();
    }
}
