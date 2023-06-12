namespace Memorabilia.Blazor.Pages.Admin.BatTypes;

public partial class ViewBatTypes 
    : ViewDomainItem<BatTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBatType(editModel));
    }
    public async Task OnLoad()
    {
        Model = new BatTypesModel(await QueryRouter.Send(new GetBatTypes()));
    }
}
