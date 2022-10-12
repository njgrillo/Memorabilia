namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class HelmetTypeEditor : EditDomainItem<HelmetType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetHelmetType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveHelmetType.Command(ViewModel));
    }
}
