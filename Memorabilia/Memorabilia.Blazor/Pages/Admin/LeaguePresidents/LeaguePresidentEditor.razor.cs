namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class LeaguePresidentEditor 
    : EditItem<LeaguePresidentEditModel, LeaguePresidentModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetLeaguePresident(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveLeaguePresident(EditModel));
    }
}
