#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class FranchiseEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private bool DisplaySportLeagueLevel;
    private SaveFranchiseViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveFranchise.Command(ViewModel)).ConfigureAwait(false);
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
        {
            DisplaySportLeagueLevel = true;
            return;
        }

        ViewModel = new SaveFranchiseViewModel(await QueryRouter.Send(new GetFranchise.Query(Id)).ConfigureAwait(false));
    }
}
