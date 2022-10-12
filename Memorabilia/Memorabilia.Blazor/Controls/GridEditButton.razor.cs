#nullable disable

namespace Memorabilia.Blazor.Controls;

public partial class GridEditButton : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Parameter]
    public string NavigationPath { get; set; }
}
