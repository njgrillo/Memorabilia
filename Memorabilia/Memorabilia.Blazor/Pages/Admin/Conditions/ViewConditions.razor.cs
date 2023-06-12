namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ViewConditions 
    : ViewDomainItem<ConditionsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveCondition(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new ConditionsModel(await QueryRouter.Send(new GetConditions()));
    }
}
