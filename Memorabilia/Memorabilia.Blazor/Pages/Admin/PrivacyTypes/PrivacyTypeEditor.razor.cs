namespace Memorabilia.Blazor.Pages.Admin.PrivacyTypes;

public partial class PrivacyTypeEditor 
    : EditDomainItem<PrivacyType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetPrivacyType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePrivacyType(EditModel));
    }
}
