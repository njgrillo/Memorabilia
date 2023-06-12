namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes;

public partial class ViewAcquisitionTypes 
    : ViewDomainItem<AcquisitionTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAcquisitionType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new AcquisitionTypesModel(await QueryRouter.Send(new GetAcquisitionTypes()));
    }
}
