namespace Memorabilia.Blazor.Pages.Admin.ProjectTypes;

public partial class EditProjectType 
    : EditDomainItem<ProjectType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetProjectType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveProjectType(EditModel));
    }
}
