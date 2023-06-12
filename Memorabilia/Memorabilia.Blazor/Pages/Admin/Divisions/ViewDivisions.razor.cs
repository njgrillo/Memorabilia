namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class ViewDivisions 
    : ViewItem<DivisionsModel, DivisionModel>
{
    protected async Task OnLoad()
    {
        Model = new DivisionsModel(await QueryRouter.Send(new GetDivisions()));
    }

    protected override async Task Delete(int id)
    {
        DivisionModel deletedItem = Model.Divisions.Single(Division => Division.Id == id);

        var editModel = new DivisionEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDivision(editModel));

        Model.Divisions.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(DivisionModel model, string search)
        => search.IsNullOrEmpty() ||
           model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!model.ConferenceName.IsNullOrEmpty() &&
            model.ConferenceName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           (!model.LeagueName.IsNullOrEmpty() &&
            model.LeagueName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           (!model.Abbreviation.IsNullOrEmpty() &&
            model.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
