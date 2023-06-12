namespace Memorabilia.Blazor.Pages.Admin.Colleges;

public partial class CollegeEditor 
    : EditDomainItem<College>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetCollege(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCollege(EditModel));
    }
}
