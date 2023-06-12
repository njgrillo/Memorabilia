namespace Memorabilia.Blazor.Pages.Admin.ItemTypeLevels;

public partial class ViewItemTypeLevels 
    : ViewItem<ItemTypeLevelsModel, ItemTypeLevelModel>
{
    protected async Task OnLoad()
    {
        ViewModel = new ItemTypeLevelsModel(await QueryRouter.Send(new GetItemTypeLevels()));
    }

    protected override async Task Delete(int id)
    {
        var deletedItem = ViewModel.ItemTypeLevels.Single(ItemTypeLevel => ItemTypeLevel.Id == id);
        var viewModel = new ItemTypeLevelEditModel(deletedItem)
        {
            IsDeleted = true
        };

        await CommandRouter.Send(new SaveItemTypeLevel(viewModel));

        ViewModel.ItemTypeLevels.Remove(deletedItem);

        ShowDeleteSuccessfulMessage(ViewModel.ItemTitle);
    }

    protected override bool FilterFunc(ItemTypeLevelModel viewModel, string search)
        => search.IsNullOrEmpty() ||
           viewModel.ItemTypeName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
           viewModel.LevelTypeName.Contains(search, StringComparison.OrdinalIgnoreCase);
}
