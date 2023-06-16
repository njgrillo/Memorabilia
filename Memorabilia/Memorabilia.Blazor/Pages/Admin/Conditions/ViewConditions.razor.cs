namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ViewConditions 
    : ViewDomainItem<ConditionsModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveCondition(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new ConditionsModel(await QueryRouter.Send(new GetConditions()));
    }
}
