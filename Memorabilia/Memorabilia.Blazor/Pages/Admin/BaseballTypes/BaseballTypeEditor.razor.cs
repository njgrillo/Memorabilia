namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class BaseballTypeEditor : EditDomainItem<BaseballType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetBaseballType(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveBaseballType(ViewModel));
    }
}
