namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class LeagueEditor : EditItem<SaveLeagueViewModel, LeagueViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveLeague(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveLeagueViewModel(await Get(new GetLeague(Id)));
    }
}
