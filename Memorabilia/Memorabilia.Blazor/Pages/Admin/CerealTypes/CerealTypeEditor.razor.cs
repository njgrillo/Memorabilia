namespace Memorabilia.Blazor.Pages.Admin.CerealTypes;

public partial class CerealTypeEditor : EditDomainItem<CerealType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetCerealType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCerealType(ViewModel));
    }
}
