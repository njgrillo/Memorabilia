namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class ViewInscriptionTypes 
    : ViewDomainItem<InscriptionTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveInscriptionType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new InscriptionTypesModel(await QueryRouter.Send(new GetInscriptionTypes()));
    }
}
