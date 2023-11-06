namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class EditInscriptionType
    : EditDomainItem<InscriptionType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetInscriptionType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveInscriptionType(EditModel));
    }
}
