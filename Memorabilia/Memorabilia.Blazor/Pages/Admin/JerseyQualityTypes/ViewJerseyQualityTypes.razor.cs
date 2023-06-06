namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class ViewJerseyQualityTypes : ViewDomainItem<JerseyQualityTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyQualityType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyQualityTypes());
    }
}
