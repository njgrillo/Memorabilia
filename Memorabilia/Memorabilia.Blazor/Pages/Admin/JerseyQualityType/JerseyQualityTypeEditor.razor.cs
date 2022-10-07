#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityType;

public partial class JerseyQualityTypeEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Jersey Quality Type";
    private const string ImagePath = "images/jerseyqualitytypes.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetJerseyQualityType.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveJerseyQualityType.Command(ViewModel)).ConfigureAwait(false);
    }
}
