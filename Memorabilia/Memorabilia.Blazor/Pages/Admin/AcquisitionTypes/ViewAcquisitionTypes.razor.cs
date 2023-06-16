namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes;

public partial class ViewAcquisitionTypes 
    : ViewDomainItem<AcquisitionTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAcquisitionType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new AcquisitionTypesModel(await QueryRouter.Send(new GetAcquisitionTypes()));
    }
}
