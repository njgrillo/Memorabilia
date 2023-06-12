namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class ViewFranchises 
    : ViewItem<FranchisesModel, FranchiseModel>
{
    protected async Task OnLoad()
    {
        Model = new FranchisesModel(await QueryRouter.Send(new GetFranchises()));
    }

    protected override async Task Delete(int id)
    {
        FranchiseModel deletedItem = Model.Franchises.Single(Franchise => Franchise.Id == id);

        var editModel = new FranchiseEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveFranchise(editModel));

        Model.Franchises.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(Model.ItemTitle);
    }

    protected override bool FilterFunc(FranchiseModel model, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               model.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               model.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && model.FoundYear == year);
    }
}
