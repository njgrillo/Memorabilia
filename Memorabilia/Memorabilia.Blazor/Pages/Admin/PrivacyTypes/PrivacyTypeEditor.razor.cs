namespace Memorabilia.Blazor.Pages.Admin.PrivacyTypes;

public partial class PrivacyTypeEditor : EditDomainItem<PrivacyType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetPrivacyType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePrivacyType.Command(ViewModel));
    }
}
