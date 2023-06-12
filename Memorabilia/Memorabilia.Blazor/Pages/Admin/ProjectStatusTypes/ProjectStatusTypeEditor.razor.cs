namespace Memorabilia.Blazor.Pages.Admin.ProjectStatusTypes;

public partial class ProjectStatusTypeEditor : EditDomainItem<ProjectStatusType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetProjectStatusType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveProjectStatusType(Model));
    }
}
