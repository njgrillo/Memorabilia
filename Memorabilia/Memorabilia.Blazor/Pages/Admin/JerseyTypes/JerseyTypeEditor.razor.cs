namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class JerseyTypeEditor : EditDomainItem<JerseyType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetJerseyType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveJerseyType.Command(ViewModel));
    }
}
