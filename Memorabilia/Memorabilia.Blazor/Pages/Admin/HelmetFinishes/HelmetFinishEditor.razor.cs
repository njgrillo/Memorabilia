namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class HelmetFinishEditor : EditDomainItem<HelmetFinish>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetHelmetFinish.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveHelmetFinish.Command(ViewModel));
    }
}
