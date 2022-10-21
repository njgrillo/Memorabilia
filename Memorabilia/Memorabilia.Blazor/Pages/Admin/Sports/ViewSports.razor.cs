namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class ViewSports : ViewItem<SportsViewModel, SportViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetSports());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Sports.Single(sport => sport.Id == id);
        var viewModel = new SaveSportViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveSport(viewModel));

        ViewModel.Sports.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(SportViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               (!viewModel.AlternateName.IsNullOrEmpty() &&
                viewModel.AlternateName.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
}
