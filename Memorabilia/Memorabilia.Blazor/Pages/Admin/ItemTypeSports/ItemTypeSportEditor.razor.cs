namespace Memorabilia.Blazor.Pages.Admin.ItemTypeSports;

public partial class ItemTypeSportEditor : EditItemTypeItem<SaveItemTypeSportViewModel, ItemTypeSportViewModel>
{
    protected async Task HandleValidSubmit()
    {
        await HandleValidSubmit(new SaveItemTypeSport(ViewModel));
    }

    protected async Task OnLoad()
    {
        Initialize();

        if (DisplayItemType)
            return;

        ViewModel = new SaveItemTypeSportViewModel(await Get(new GetItemTypeSport(Id)));
    }
}
