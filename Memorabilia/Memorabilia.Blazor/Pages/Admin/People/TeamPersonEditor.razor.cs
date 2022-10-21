namespace Memorabilia.Blazor.Pages.Admin.People;

public partial class TeamPersonEditor : EditPersonItem<SavePersonTeamsViewModel, PersonTeamViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SavePersonTeam.Command(PersonId, ViewModel.Teams));
    }

    protected async Task OnLoad()
    {
        ViewModel = new SavePersonTeamsViewModel(await QueryRouter.Send(new GetPersonTeams(PersonId)));
    }    
}
