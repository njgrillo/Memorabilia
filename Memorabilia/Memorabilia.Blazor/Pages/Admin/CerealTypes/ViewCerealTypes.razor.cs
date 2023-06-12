namespace Memorabilia.Blazor.Pages.Admin.CerealTypes;

public partial class ViewCerealTypes 
    : ViewDomainItem<CerealTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveCerealType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new CerealTypesModel(await QueryRouter.Send(new GetCerealTypes()));
    }
}
