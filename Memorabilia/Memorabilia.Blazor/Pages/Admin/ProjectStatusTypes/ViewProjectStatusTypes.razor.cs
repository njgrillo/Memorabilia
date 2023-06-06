namespace Memorabilia.Blazor.Pages.Admin.ProjectStatusTypes;

public partial class ViewProjectStatusTypes 
    : ViewDomainItem<ProjectStatusTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveProjectStatusType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetProjectStatusTypes());
    }
}
