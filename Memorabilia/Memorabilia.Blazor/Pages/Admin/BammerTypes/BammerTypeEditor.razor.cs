namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class BammerTypeEditor : EditDomainItem<BammerType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetBammerType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBammerType.Command(ViewModel));
    }
}
