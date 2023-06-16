namespace Memorabilia.Blazor.Pages.Admin.CerealTypes;

public partial class ViewCerealTypes 
    : ViewDomainItem<CerealTypesModel>
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveCerealType(editModel));
    }

    protected override async Task OnInitializedAsync()
    {
        Model = new CerealTypesModel(await QueryRouter.Send(new GetCerealTypes()));
    }
}
