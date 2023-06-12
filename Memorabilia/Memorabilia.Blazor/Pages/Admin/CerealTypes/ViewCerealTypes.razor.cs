namespace Memorabilia.Blazor.Pages.Admin.CerealTypes;

public partial class ViewCerealTypes 
    : ViewDomainItem<CerealTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveCerealType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new CerealTypesModel(await QueryRouter.Send(new GetCerealTypes()));
    }
}
