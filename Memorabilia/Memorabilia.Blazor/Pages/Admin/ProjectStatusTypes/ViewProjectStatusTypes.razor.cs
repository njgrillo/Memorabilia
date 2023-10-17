namespace Memorabilia.Blazor.Pages.Admin.ProjectStatusTypes;

public partial class ViewProjectStatusTypes 
    : ViewDomainItem<ProjectStatusTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveProjectStatusType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ProjectStatusTypesModel(await Mediator.Send(new GetProjectStatusTypes()));
    }
}
