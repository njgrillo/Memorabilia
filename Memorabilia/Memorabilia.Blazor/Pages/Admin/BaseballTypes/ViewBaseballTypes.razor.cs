namespace Memorabilia.Blazor.Pages.Admin.BaseballTypes;

public partial class ViewBaseballTypes 
    : ViewDomainItem<BaseballTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveBaseballType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new BaseballTypesModel(await QueryRouter.Send(new GetBaseballTypes()));
    }
}
