namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ConditionEditor 
    : EditDomainItem<Condition>
{
    protected override async Task OnInitializedAsync()
    {
        await OnLoad(new GetCondition(Id));
    }

    public async Task OnSave()
    {
        await OnSave(new SaveCondition(EditModel));
    }
}
