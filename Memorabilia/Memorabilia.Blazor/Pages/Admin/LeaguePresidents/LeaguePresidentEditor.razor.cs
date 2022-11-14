namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class LeaguePresidentEditor : EditItem<SaveLeaguePresidentViewModel, LeaguePresidentViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveLeaguePresident(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveLeaguePresidentViewModel(await Get(new GetLeaguePresident(Id)));
    }
}
