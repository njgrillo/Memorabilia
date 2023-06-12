namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class ViewBammerTypes : ViewDomainItem<BammerTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await OnDelete(new SaveBammerType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new BammerTypesModel(await QueryRouter.Send(new GetBammerTypes()));
    }
}
