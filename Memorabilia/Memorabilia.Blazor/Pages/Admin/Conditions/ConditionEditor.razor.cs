namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ConditionEditor : EditDomainItem<Domain.Constants.Condition>, IEditDomainItem
{
    public async Task OnLoad()
    {
        await OnLoad(new GetCondition.Query(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCondition.Command(ViewModel));
    }
}
