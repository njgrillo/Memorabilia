#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class HelmetFinishEditor : ComponentBase, IEditDomainItem
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private const string DomainTypeName = "Helmet Finish";
    private const string ImagePath = "images/minihelmets.jpg";
    private readonly string NavigationPath = $"{DomainTypeName.Replace(" ", "")}es";
    private SaveDomainViewModel ViewModel;

    protected override void OnInitialized()
    {
        ViewModel = new SaveDomainViewModel(Id, DomainTypeName, ImagePath, NavigationPath);
    }

    public async Task OnLoad()
    {
        ViewModel = new SaveDomainViewModel(await QueryRouter.Send(new GetHelmetFinish.Query(Id)).ConfigureAwait(false),
                                             DomainTypeName,
                                             ImagePath,
                                             NavigationPath);
    }

    public async Task OnSave()
    {
        await CommandRouter.Send(new SaveHelmetFinish.Command(ViewModel)).ConfigureAwait(false);
    }
}
