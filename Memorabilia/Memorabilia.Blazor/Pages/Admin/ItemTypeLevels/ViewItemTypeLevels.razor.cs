namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ViewItemTypeLevels : ViewItem<ItemTypeLevelsViewModel, ItemTypeLevelViewModel>
{
    protected async Task OnLoad()
    {
        await OnLoad(new GetItemTypeLevels());
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeLevels.Single(ItemTypeLevel => ItemTypeLevel.Id == id);
        var viewModel = new SaveItemTypeLevelViewModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeLevel(viewModel));

        ViewModel.ItemTypeLevels.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeLevelViewModel viewModel, string search)
    {
        return search.IsNullOrEmpty() ||
               viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
               viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}
