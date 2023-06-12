namespace Memorabilia.Blazor.Pages.Admin.HelmetQualityTypes;

public partial class ViewHelmetQualityTypes 
    : ViewDomainItem<HelmetQualityTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveHelmetQualityType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new HelmetQualityTypesModel(await QueryRouter.Send(new GetHelmetQualityTypes()));
    }
}
