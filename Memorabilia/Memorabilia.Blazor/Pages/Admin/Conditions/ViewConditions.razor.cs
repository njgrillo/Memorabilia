namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ViewConditions 
    : ViewDomainItem<ConditionsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveCondition(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ConditionsModel(await QueryRouter.Send(new GetConditions()));
    }
}
