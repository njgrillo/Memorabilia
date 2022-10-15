namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class ViewJerseyQualityTypes : ViewDomainItem<JerseyQualityTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyQualityType.Command(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = await QueryRouter.Send(new GetJerseyQualityTypes.Query());
    }
}
