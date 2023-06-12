namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ViewItemTypeGameStyles 
    : ViewItem<ItemTypeGameStylesModel, ItemTypeGameStyleModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ItemTypeGameStylesModel(await QueryRouter.Send(new GetItemTypeGameStyles()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeGameStyles.Single(itemTypeGameStyle => itemTypeGameStyle.Id == id);
        var viewModel = new ItemTypeGameStyleEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeGameStyle(viewModel));

        ViewModel.ItemTypeGameStyles.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeGameStyleModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.GameStyleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
