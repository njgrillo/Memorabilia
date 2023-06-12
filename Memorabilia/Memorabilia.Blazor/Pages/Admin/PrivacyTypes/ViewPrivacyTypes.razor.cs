namespace Memorabilia.Blazor.Pages.Admin.PrivacyTypes;

public partial class ViewPrivacyTypes 
    : ViewDomainItem<PrivacyTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SavePrivacyType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new PrivacyTypesModel(await QueryRouter.Send(new GetPrivacyTypes()));
    }
}
