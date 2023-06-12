namespace Memorabilia.Blazor.Pages.Admin.AcquisitionTypes;

public partial class AcquisitionTypeEditor : EditDomainItem<AcquisitionType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetAcquisitionType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveAcquisitionType(Model));
    }
}
