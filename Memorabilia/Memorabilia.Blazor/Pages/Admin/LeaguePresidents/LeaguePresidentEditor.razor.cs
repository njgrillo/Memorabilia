namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class LeaguePresidentEditor 
    : EditItem<LeaguePresidentEditModel, LeaguePresidentModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveLeaguePresident(EditModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        EditModel = new LeaguePresidentEditModel(new LeaguePresidentModel(await QueryRouter.Send(new GetLeaguePresident(Id))));
    }
}
