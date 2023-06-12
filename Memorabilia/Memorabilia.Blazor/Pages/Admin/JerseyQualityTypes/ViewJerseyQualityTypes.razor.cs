namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class ViewJerseyQualityTypes 
    : ViewDomainItem<JerseyQualityTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveJerseyQualityType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new JerseyQualityTypesModel(await QueryRouter.Send(new GetJerseyQualityTypes()));
    }
}
