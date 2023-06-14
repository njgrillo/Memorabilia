namespace Memorabilia.Web;

public abstract class WebPage : ComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; }
}
