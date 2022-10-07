﻿#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class LeagueEditor : ComponentBase
{
    [Inject]
    public CommandRouter CommandRouter { get; set; }

    [Inject]
    public QueryRouter QueryRouter { get; set; }

    [Parameter]
    public int Id { get; set; }

    private SaveLeagueViewModel ViewModel = new ();

    protected async Task HandleValidSubmit()
    {
        await CommandRouter.Send(new SaveLeague.Command(ViewModel)).ConfigureAwait(false);
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveLeagueViewModel(await QueryRouter.Send(new GetLeague.Query(Id)).ConfigureAwait(false));
    }
}
