namespace Memorabilia.Blazor.Pages.Admin.ProjectStatusTypes;

public partial class ViewProjectStatusTypes 
    : ViewDomainItem<ProjectStatusTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveProjectStatusType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ProjectStatusTypesModel(await QueryRouter.Send(new GetProjectStatusTypes()));
    }
}
