namespace Memorabilia.Blazor.Pages.Admin.LeaguePresidents;

public partial class ViewLeaguePresidents 
    : ViewItem<LeaguePresidentsModel, LeaguePresidentModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new LeaguePresidentsModel(await Mediator.Send(new GetLeaguePresidents()));
    }

    protected override async Task Delete(int id)
    {
        LeaguePresidentModel deletedItem 
            = Model.Presidents.Single(president => president.Id == id);

        var editModel = new LeaguePresidentEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveLeaguePresident(editModel));

        Model.Presidents.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(LeaguePresidentModel model, string search)
    {
        bool isYear = search.TryParse(out int year);

        return search.IsNullOrEmpty() ||
               model.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && model?.BeginYear == year) ||
               (isYear && model?.EndYear == year) ||
               (model.Person != null &&
                model.Person.DisplayName.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
