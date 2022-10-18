namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class HelmetQualityTypeEditor : EditDomainItem<HelmetQualityType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetHelmetQualityType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveHelmetQualityType(ViewModel));
    }
}
