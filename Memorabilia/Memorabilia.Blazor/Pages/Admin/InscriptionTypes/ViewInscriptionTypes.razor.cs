namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class ViewInscriptionTypes 
    : ViewDomainItem<InscriptionTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveInscriptionType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new InscriptionTypesModel(await QueryRouter.Send(new GetInscriptionTypes()));
    }
}
