namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class LeaguePresidentEditor 
    : EditItem<LeaguePresidentEditModel, LeaguePresidentModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveLeaguePresident(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new LeaguePresidentEditModel(new LeaguePresidentModel(await QueryRouter.Send(new GetLeaguePresident(Id))));
    }
}
