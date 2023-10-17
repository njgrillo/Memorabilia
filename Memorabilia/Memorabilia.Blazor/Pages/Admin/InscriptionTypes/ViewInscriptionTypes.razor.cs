namespace Memorabilia.Blazor.Pages.Admin.InscriptionTypes;

public partial class ViewInscriptionTypes 
    : ViewDomainItem<InscriptionTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await Mediator.Send(new SaveInscriptionType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new InscriptionTypesModel(await Mediator.Send(new GetInscriptionTypes()));
    }
}
