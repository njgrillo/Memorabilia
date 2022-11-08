#nullable disable

namespace Memorabilia.Blazor;

public class NavigationItem : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
}
