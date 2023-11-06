namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class EditHelmetType 
    : EditDomainItem<HelmetType>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetHelmetType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveHelmetType(EditModel));
    }
}
