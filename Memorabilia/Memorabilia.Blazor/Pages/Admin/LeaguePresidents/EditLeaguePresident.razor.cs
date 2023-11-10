namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class EditLeaguePresident
    : EditItem<LeaguePresidentEditModel, LeaguePresidentModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetLeaguePresident(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveLeaguePresident(EditModel));
    }
}
