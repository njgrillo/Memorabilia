#nullable disable

namespace Memorabilia.Blazor.Pages.Admin.Pewters;

public partial class ViewPewters : ViewItem<PewtersViewModel, PewterViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetPewters());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Pewters.Single(pewter => pewter.Id == id);
        var viewModel = new SavePewterViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SavePewter(viewModel));

        ViewModel.Pewters.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(PewterViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.FranchiseName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.TeamName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SizeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
