namespace Memorabilia.Blazor.Pages.Admin.ProjectTypes;

public partial class ViewProjectTypes 
    : ViewDomainItem<ProjectTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveProjectType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ProjectTypesModel(await QueryRouter.Send(new GetProjectTypes()));
    }
}
