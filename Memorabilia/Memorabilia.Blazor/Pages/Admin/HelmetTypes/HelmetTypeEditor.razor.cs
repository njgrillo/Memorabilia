#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class HelmetTypeEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Helmet Type";
    private const string ImagePath = "images/helmettypes.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetHelmetType.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveHelmetType.Command(ViewModel)).ConfigureAwait(false);
    }
}
