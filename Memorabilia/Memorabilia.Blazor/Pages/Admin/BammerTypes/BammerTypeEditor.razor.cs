namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class BammerTypeEditor : EditDomainItem<BammerType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetBammerType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBammerType(Model));
    }
}
