namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditItemTypeItem<TSaveViewModel, TViewModel> : EditItem<TSaveViewModel, TViewModel>
{
    protected bool DisplayItemType;

    protected override void Initialize()
    {
        DisplayItemType = Id == 0;
    }
}
