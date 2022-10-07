#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypes;

public partial class ItemTypeEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Item Type";
    private const string ImagePath = "images/itemtypes.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetItemType.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveItemType.Command(ViewModel)).ConfigureAwait(false);
    }
}
