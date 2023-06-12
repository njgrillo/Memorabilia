namespace Memorabilia.Blazor.Pages.Admin.PrivacyTypes;

public partial class ViewPrivacyTypes 
    : ViewDomainItem<PrivacyTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SavePrivacyType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new PrivacyTypesModel(await QueryRouter.Send(new GetPrivacyTypes()));
    }
}
