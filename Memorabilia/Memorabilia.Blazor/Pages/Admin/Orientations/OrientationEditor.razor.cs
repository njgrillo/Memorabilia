namespace Memorabilia.Blazor.Pages.Admin.Orientations;

public partial class OrientationEditor 
    : EditDomainItem<Constant.Orientation>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetOrientation(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveOrientation(EditModel));
    }
}
