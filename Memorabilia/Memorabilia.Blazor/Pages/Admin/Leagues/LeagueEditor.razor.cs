namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class LeagueEditor 
    : EditItem<LeagueEditModel, LeagueModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveLeague(EditModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        EditModel = new LeagueEditModel(new LeagueModel(await QueryRouter.Send(new GetLeague(Id))));
    }
}
