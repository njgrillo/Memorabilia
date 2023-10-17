namespace Memorabilia.Blazor.Pages.Admin.Teams;

public partial class ViewTeams 
    : ViewItem<TeamsModel, TeamModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new TeamsModel(await Mediator.Send(new GetTeams()));
    }

    protected override async Task Delete(int id)
    {
        TeamModel deletedItem = Model.Teams.Single(team => team.Id == id);

        var editModel = new TeamEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await Mediator.Send(new SaveTeam.Command(editModel));

        Model.Teams.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(TeamModel model, string search)
    {
        bool isYear = search.TryParse(out int year);

        return search.IsNullOrEmpty() ||
               model.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!model.Nickname.IsNullOrEmpty() &&
                model.Nickname.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (!model.Abbreviation.IsNullOrEmpty() &&
                model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (isYear && model?.BeginYear == year) ||
               (isYear && model?.EndYear == year);
    }
}
