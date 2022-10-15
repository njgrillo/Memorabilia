#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class DivisionEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private SaveDivisionViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveDivision.Command(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveDivisionViewModel(await QueryRouter.Send(new GetDivision.Query(Id)));
    }
}
