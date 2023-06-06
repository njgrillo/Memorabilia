namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class ViewJerseyTypes : ViewDomainItem<JerseyTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyTypes());
    }
}
