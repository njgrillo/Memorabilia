#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class InscriptionTypeEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Inscription Type";
    private const string ImagePath = "images/inscriptiontypes.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}s";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        var query = new GetInscriptionType.Query(Id);

        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(query).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveInscriptionType.Command(ViewModel)).ConfigureAwait(false);
    }
}
