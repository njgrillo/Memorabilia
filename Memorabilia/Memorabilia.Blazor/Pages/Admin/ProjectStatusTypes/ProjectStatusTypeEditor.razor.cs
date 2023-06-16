namespace Memorabilia.Blazor.Pages.Admin.ProjectStatusTypes;

public partial class ProjectStatusTypeEditor 
    : EditDomainItem<ProjectStatusType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetProjectStatusType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveProjectStatusType(EditModel));
    }
}
