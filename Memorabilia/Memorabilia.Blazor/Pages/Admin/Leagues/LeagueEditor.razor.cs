namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class LeagueEditor 
    : EditItem<LeagueEditModel, LeagueModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetLeague(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveLeague(EditModel));
    }
}
