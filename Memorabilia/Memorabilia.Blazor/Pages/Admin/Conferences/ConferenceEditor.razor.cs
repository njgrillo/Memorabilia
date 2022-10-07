#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Conferences;

public partial class ConferenceEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private SaveConferenceViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveConference.Command(ViewModel)).ConfigureAwait(false);
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveConferenceViewModel(await QueryRouter.Send(new GetConference.Query(Id)).ConfigureAwait(false));
    }
}
