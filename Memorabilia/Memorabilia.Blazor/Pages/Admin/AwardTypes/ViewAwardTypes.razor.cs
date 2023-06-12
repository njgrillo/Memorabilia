namespace Memorabilia.Blazor.Pages.Admin.AwardTypes;

public partial class ViewAwardTypes 
    : ViewDomainItem<AwardTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveAwardType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new AwardTypesModel(await QueryRouter.Send(new GetAwardTypes()));
    }
}
