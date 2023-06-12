namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class ViewInscriptionTypes 
    : ViewDomainItem<InscriptionTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveInscriptionType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new InscriptionTypesModel(await QueryRouter.Send(new GetInscriptionTypes()));
    }
}
