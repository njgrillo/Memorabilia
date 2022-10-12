namespace Memorabilia.Blazor.Pages.Admin.AwardTypes;

public partial class AwardTypeEditor : EditDomainItem<AwardType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetAwardType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveAwardType.Command(ViewModel));
    }
}
