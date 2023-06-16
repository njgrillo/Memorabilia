namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class ViewSports 
    : ViewItem<SportsModel, SportModel>
{
    protected override async Task OnInitializedAsync()
    {
        Model = new SportsModel(await QueryRouter.Send(new GetSports()));
    }

    protected override async Task Delete(int id)
    {
        SportModel deletedItem = Model.Sports.Single(sport => sport.Id == id);

        var editModel = new SportEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveSport(editModel));

        Model.Sports.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(SportModel model, string search)
        => search.IsNullOrEmpty() ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.AlternateName.IsNullOrEmpty() &&
            model.AlternateName.Contains(search, StringComparison.OrdinalIgnoreCase));
}
