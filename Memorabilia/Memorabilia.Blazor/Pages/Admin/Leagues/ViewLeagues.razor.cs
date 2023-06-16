namespace Memorabilia.Blazor.Pages.Admin.Leagues;

public partial class ViewLeagues 
    : ViewItem<LeaguesModel, LeagueModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new LeaguesModel(await QueryRouter.Send(new GetLeagues()));
    }

    protected override async Task Delete(int id)
    {
        LeagueModel deletedItem = Model.Leagues.Single(League => League.Id == id);

        var editModel = new LeagueEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveLeague(editModel));

        Model.Leagues.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(LeagueModel model, string search)
        => search.IsNullOrEmpty() ||
           model.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.Abbreviation.IsNullOrEmpty() &&
            model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
