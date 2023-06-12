namespace Memorabilia.Blazor.Pages.Admin.Divisions;

public partial class ViewDivisions : ViewItem<DivisionsModel, DivisionModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new DivisionsModel(await QueryRouter.Send(new GetDivisions()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Divisions.Single(Division => Division.Id == id);
        var viewModel = new DivisionEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveDivision(viewModel));

        ViewModel.Divisions.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(DivisionModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!viewModel.ConferenceName.IsNullOrEmpty() &&
            viewModel.ConferenceName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           (!viewModel.LeagueName.IsNullOrEmpty() &&
            viewModel.LeagueName.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
           (!viewModel.Abbreviation.IsNullOrEmpty() &&
            viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
