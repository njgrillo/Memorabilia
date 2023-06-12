namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class InscriptionTypeEditor : EditDomainItem<InscriptionType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetInscriptionType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveInscriptionType(Model));
    }
}
