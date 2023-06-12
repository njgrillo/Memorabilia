namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class ViewPewters 
    : ViewItem<PewtersModel, PewterModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new PewtersModel(await QueryRouter.Send(new GetPewters()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Pewters.Single(pewter => pewter.Id == id);
        var viewModel = new PewterEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePewter(viewModel));

        ViewModel.Pewters.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PewterModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
