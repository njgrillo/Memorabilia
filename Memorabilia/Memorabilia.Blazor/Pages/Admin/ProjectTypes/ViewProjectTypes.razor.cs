namespace Memorabilia.Blazor.Pages.Admin.ProjectTypes;

public partial class ViewProjectTypes 
    : ViewDomainItem<ProjectTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveProjectType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ProjectTypesModel(await Mediator.Send(new GetProjectTypes()));
    }
}
