﻿namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class SportLeagueLevelEditor 
    : EditItem<SportLeagueLevelEditModel, SportLeagueLevelModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveSportLeagueLevel(ViewModel));
    }

    protected async Task OnLoad()
    {
        if (Id == 0)
            return;

        ViewModel = new SportLeagueLevelEditModel(new SportLeagueLevelModel(await QueryRouter.Send(new GetSportLeagueLevel(Id))));
    }
}
