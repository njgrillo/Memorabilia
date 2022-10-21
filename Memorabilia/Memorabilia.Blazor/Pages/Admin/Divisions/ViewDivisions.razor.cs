namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class ViewDivisions : ViewItem<DivisionsViewModel, DivisionViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetDivisions());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Divisions.Single(Division => Division.Id == id);
        var viewModel = new SaveDivisionViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDivision(viewModel));

        ViewModel.Divisions.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(DivisionViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.ConferenceName.IsNullOrEmpty() &&
                viewModel.ConferenceName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (!viewModel.LeagueName.IsNullOrEmpty() &&
                viewModel.LeagueName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
