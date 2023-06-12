namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class ViewHelmetQualityTypes 
    : ViewDomainItem<HelmetQualityTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetQualityType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new HelmetQualityTypesModel(await QueryRouter.Send(new GetHelmetQualityTypes()));
    }
}
