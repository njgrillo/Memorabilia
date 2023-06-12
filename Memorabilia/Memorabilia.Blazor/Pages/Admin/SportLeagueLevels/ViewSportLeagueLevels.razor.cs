namespace Memorabilia.Blazor.Pages.Admin.SportLeagueLevels;

public partial class ViewSportLeagueLevels 
    : ViewItem<SportLeagueLevelsModel, SportLeagueLevelModel>
{
    protected async Task OnLoad()
    {
        Model = new SportLeagueLevelsModel(await QueryRouter.Send(new GetSportLeagueLevels()));
    }

    protected override async Task Delete(int id)
    {
        SportLeagueLevelModel deletedItem 
            = Model.SportLeagueLevels.Single(sportLeagueLevel => sportLeagueLevel.Id == id);

        var editModel = new SportLeagueLevelEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveSportLeagueLevel(editModel));

        Model.SportLeagueLevels.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(SportLeagueLevelModel model, string search)
        => search.IsNullOrEmpty() ||
           model.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.Abbreviation.IsNullOrEmpty() &&
            model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
