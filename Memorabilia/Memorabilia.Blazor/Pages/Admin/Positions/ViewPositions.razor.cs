namespace Memorabilia.Blazor.Pages.Admin.Positions;

public partial class ViewPositions : ViewItem<PositionsViewModel, PositionViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetPositions());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Positions.Single(position => position.Id == id);
        var viewModel = new SavePositionViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePosition(viewModel));

        ViewModel.Positions.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PositionViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.Abbreviation.IsNullOrEmpty() &&
                viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
