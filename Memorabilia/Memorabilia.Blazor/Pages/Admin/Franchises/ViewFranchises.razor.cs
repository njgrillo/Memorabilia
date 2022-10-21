namespace Memorabilia.Blazor.Pages.Admin.Franchises;

public partial class ViewFranchises : ViewItem<FranchisesViewModel, FranchiseViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetFranchises());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Franchises.Single(Franchise => Franchise.Id == id);
        var viewModel = new SaveFranchiseViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveFranchise(viewModel));

        ViewModel.Franchises.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(FranchiseViewModel viewModel, string search)
    {
        var isYear = int.TryParse(search, out var year);

        return search.IsNullOrEmpty() ||
               viewModel.SportLeagueLevelName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Location.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (isYear && viewModel.FoundYear == year);
    }
}
