#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSpots;

public partial class ItemTypeSpotsEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private bool DisplayItemType;
    private SaveItemTypeSpotViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveItemTypeSpot(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplayItemType = true;
            return;
        }

        ViewModel = new SaveItemTypeSpotViewModel(await QueryRouter.Send(new GetItemTypeSpot(Id)));
    }
}
