namespace Memorabilia.Blazor.Pages.Admin.PriorityTypes;

public partial class PriorityTypeEditor : EditDomainItem<PriorityType>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetPriorityType.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SavePriorityType.Command(ViewModel));
    }
}
