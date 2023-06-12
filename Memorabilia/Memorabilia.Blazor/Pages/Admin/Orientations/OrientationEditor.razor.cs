namespace Memorabilia.Blazor.Pages.Admin.Orientations;

public partial class OrientationEditor 
    : EditDomainItem<Constant.Orientation>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetOrientation(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveOrientation(EditModel));
    }
}
