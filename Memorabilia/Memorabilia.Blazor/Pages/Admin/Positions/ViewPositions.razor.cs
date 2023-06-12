namespace Memorabilia.Blazor.Pages.Admin.Positions;

public partial class ViewPositions 
    : ViewItem<PositionsModel, PositionModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new PositionsModel(await QueryRouter.Send(new GetPositions()));
    }

    protected override async Task Delete(int id)
    {
        PositionModel deletedItem = ViewModel.Positions.Single(position => position.Id == id);
        var viewModel = new PositionEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePosition(viewModel));

        ViewModel.Positions.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PositionModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!viewModel.Abbreviation.IsNullOrEmpty() &&
            viewModel.Abbreviation.Contains(search, StringComparison.OrdinalIgnoreCase));
}
