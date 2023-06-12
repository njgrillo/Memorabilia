namespace Memorabilia.Blazor.Pages.Admin;

public abstract class EditItemTypeItem<TSaveModel, TModel> 
    : EditItem<TSaveModel, TModel>
{
    protected bool DisplayItemType;

    protected override void Initialize()
    {
        DisplayItemType = Id == 0;
    }
}
