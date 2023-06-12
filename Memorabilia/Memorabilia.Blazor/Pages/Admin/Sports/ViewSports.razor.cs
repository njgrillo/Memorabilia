namespace Memorabilia.Blazor.Pages.Admin.Sports;

public partial class ViewSports 
    : ViewItem<SportsModel, SportModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new SportsModel(await QueryRouter.Send(new GetSports()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.Sports.Single(sport => sport.Id == id);
        var viewModel = new SportEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveSport(viewModel));

        ViewModel.Sports.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(SportModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           (!viewModel.AlternateName.IsNullOrEmpty() &&
            viewModel.AlternateName.Contains(search, StringComparison.OrdinalIgnoreCase));
}
