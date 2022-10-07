#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class BaseballTypeEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Baseball Type";
    private const string ImagePath = "images/baseballtypes.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetBaseballType.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveBaseballType.Command(ViewModel)).ConfigureAwait(false);
    }
}
