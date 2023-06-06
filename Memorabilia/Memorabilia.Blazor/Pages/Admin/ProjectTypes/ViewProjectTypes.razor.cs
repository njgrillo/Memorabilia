namespace Memorabilia.Blazor.Pages.Admin.ProjectTypes;

public partial class ViewProjectTypes : ViewDomainItem<ProjectTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveProjectType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetProjectTypes());
    }
}
