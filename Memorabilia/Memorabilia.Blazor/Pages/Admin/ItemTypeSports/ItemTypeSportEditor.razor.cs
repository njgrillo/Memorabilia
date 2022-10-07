#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ItemTypeSportEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private bool DisplayItemType;
    private SaveItemTypeSportViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveItemTypeSport.Command(ViewModel)).ConfigureAwait(false);
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplayItemType = true;
            return;
        }

        ViewModel = new SaveItemTypeSportViewModel(await QueryRouter.Send(new GetItemTypeSport.Query(Id)).ConfigureAwait(false));
    }
}
