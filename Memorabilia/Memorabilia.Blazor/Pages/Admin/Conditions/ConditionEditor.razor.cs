namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ConditionEditor 
    : EditDomainItem<Condition>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetCondition(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCondition(EditModel));
    }
}
