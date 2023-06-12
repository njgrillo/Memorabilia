namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class JerseyQualityTypeEditor : EditDomainItem<JerseyQualityType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetJerseyQualityType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyQualityType(Model));
    }
}
