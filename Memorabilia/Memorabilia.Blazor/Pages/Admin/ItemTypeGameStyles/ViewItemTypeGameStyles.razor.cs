namespace Memorabilia.Blazor.Pages.Admin.ItemTypeGameStyles;

public partial class ViewItemTypeGameStyles : ViewItem<ItemTypeGameStylesViewModel, ItemTypeGameStyleViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetItemTypeGameStyles());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeGameStyles.Single(itemTypeGameStyle => itemTypeGameStyle.Id == id);
        var viewModel = new SaveItemTypeGameStyleViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeGameStyle(viewModel));

        ViewModel.ItemTypeGameStyles.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeGameStyleViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.GameStyleTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
