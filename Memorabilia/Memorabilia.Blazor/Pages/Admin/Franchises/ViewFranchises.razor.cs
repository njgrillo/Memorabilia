namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class ViewFranchises 
    : ViewItem<FranchisesModel, FranchiseModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new FranchisesModel(await QueryRouter.Send(new GetFranchises()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Franchises.Single(Franchise => Franchise.Id == id);
        var viewModel = new FranchiseEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveFranchise(viewModel));

        ViewModel.Franchises.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(FranchiseModel viewModel, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && viewModel.FoundYear == year);
    }
}
