namespace Memorabilia.Blazor.Pages.Admin.CerealTypes;

public partial class EditCerealType
    : EditDomainItem<CerealType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetCerealType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCerealType(EditModel));
    }
}
