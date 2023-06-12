namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class SportLeagueLevelEditor 
    : EditItem<SportLeagueLevelEditModel, SportLeagueLevelModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveSportLeagueLevel(EditModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        EditModel = (await QueryRouter.Send(new GetSportLeagueLevel(Id))).ToEditModel();
    }
}
