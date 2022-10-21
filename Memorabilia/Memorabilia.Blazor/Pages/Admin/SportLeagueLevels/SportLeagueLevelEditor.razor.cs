namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class SportLeagueLevelEditor : EditItem<SaveSportLeagueLevelViewModel, SportLeagueLevelViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveSportLeagueLevel(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SaveSportLeagueLevelViewModel(await Get(new GetSportLeagueLevel(Id)));
    }
}
