namespace Memorabilia.Blazor.Pages.Admin.ProjectStatusTypes;

public partial class ViewProjectStatusTypes 
    : ViewDomainItem<ProjectStatusTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveProjectStatusType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new ProjectStatusTypesModel(await QueryRouter.Send(new GetProjectStatusTypes()));
    }
}
