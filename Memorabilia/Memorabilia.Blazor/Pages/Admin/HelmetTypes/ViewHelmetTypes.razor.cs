namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class ViewHelmetTypes 
    : ViewDomainItem<HelmetTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveHelmetType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new HelmetTypesModel(await QueryRouter.Send(new GetHelmetTypes()));
    }
}
