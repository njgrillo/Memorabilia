namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class JerseyTypeEditor : EditDomainItem<JerseyType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetJerseyType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyType(Model));
    }
}
