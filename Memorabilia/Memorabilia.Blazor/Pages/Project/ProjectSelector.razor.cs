namespace Memorabilia.Blazor.Pages.Project;

public partial class ProjectSelector
{
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public EventCallback<ProjectType> OnProjectTypeSelected { get; set; }

    [Parameter]
    public ProjectType SelectedProjectType { get; set; }    

    protected async Task ProjectTypeSelected(ProjectType projectType)
    {
        SelectedProjectType = projectType;

        await OnProjectTypeSelected.InvokeAsync(SelectedProjectType);
    }
}
