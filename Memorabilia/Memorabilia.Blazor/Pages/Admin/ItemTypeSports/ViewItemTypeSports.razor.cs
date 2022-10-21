namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ViewItemTypeSports : ViewItem<ItemTypeSportsViewModel, ItemTypeSportViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetItemTypeSports());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSports.Single(ItemTypeSport => ItemTypeSport.Id == id);
        var viewModel = new SaveItemTypeSportViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSport(viewModel));

        ViewModel.ItemTypeSports.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSportViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
