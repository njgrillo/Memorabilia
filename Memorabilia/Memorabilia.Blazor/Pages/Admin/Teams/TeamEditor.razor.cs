namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class TeamEditor : EditItem<SaveTeamViewModel, TeamViewModel>
{
    protected async Task HandleValidSubmit()
    {
        var command = new SaveTeam.Command(ViewModel);

        await CommandRouter.Send(command);

        ViewModel.Id = command.Id;
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveTeamViewModel(await Get(new GetTeam(Id)));
    }
}
