#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ItemTypeLevelEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private bool DisplayItemType;
    private SaveItemTypeLevelViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveItemTypeLevel(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplayItemType = true;
            return;
        }

        ViewModel = new SaveItemTypeLevelViewModel(await QueryRouter.Send(new GetItemTypeLevel(Id)));
    }
}
