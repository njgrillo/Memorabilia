namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ViewConditions : ViewDomainItem<ConditionsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveCondition(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetConditions());
    }
}
