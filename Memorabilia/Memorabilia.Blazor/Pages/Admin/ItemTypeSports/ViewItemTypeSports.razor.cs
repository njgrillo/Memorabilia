namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ViewItemTypeSports 
    : ViewItem<ItemTypeSportsModel, ItemTypeSportModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ItemTypeSportsModel(await QueryRouter.Send(new GetItemTypeSports()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeSports.Single(ItemTypeSport => ItemTypeSport.Id == id);
        var viewModel = new ItemTypeSportEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeSport(viewModel));

        ViewModel.ItemTypeSports.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeSportModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.SportName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
