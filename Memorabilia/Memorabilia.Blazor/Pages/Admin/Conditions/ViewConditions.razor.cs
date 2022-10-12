namespace Memorabilia.Blazor.Pages.Admin.Conditions;

public partial class ViewConditions : ViewDomainItem<ConditionsViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveCondition.Command(viewModel)).ConfigureAwait(false);
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetConditions.Query()).ConfigureAwait(false);
    }
}
