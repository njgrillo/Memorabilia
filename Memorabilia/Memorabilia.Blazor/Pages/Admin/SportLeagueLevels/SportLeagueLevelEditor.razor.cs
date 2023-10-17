namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class SportLeagueLevelEditor 
    : EditItem<SportLeagueLevelEditModel, SportLeagueLevelModel>
{
    protected override async Task OnInitializedAsync()
    {
        if (Id == 0)
            return;

        EditModel = (await Mediator.Send(new GetSportLeagueLevel(Id))).ToEditModel();
    }

    protected async Task Save()
    {
        await Save(new SaveSportLeagueLevel(EditModel));
    }
}
