namespace Memorabilia.Blazor.Pages.Admin.Orientations;

public partial class OrientationEditor : EditDomainItem<Domain.Constants.Orientation>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetOrientation(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveOrientation(ViewModel));
    }
}
