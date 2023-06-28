namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class TeamEditor : EditItem<TeamEditModel, TeamModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetTeam(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        var command = new SaveTeam.Command(EditModel);

        await CommandRouter.Send(command);

        EditModel.Id = command.Id;
    }
}
