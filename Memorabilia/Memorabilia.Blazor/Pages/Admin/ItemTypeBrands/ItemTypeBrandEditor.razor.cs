#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.ItemTypeBrands;

public partial class ItemTypeBrandEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private bool DisplayItemType;
    private SaveItemTypeBrandViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveItemTypeBrand(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplayItemType = true;
            return;
        }

        ViewModel = new SaveItemTypeBrandViewModel(await QueryRouter.Send(new GetItemTypeBrand(Id)));
    }
}
