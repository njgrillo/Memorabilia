#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ItemTypeGameStyleEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private bool DisplayItemType;
    private SaveItemTypeGameStyleViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveItemTypeGameStyle.Command(ViewModel)).ConfigureAwait(false);
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplayItemType = true;
            return;
        }

        ViewModel = new SaveItemTypeGameStyleViewModel(await QueryRouter.Send(new GetItemTypeGameStyle.Query(Id)).ConfigureAwait(false));
    }
}
