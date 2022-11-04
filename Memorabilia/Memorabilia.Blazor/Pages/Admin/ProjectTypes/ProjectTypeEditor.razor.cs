namespace Memorabilia.Blazor.Pages.Admin.ProjectTypes;

public partial class ProjectTypeEditor : EditDomainItem<ProjectType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetProjectType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveProjectType(ViewModel));
    }
}
