namespace Memorabilia.Web.Shared;

public partial class NavMenu
{
    [Inject]
    public IApplicationStateService ApplicationStateService { get; set; }
}
