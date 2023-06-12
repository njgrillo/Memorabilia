namespace Memorabilia.Blazor.Pages.Admin.JerseyQualityTypes;

public partial class ViewJerseyQualityTypes 
    : ViewDomainItem<JerseyQualityTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveJerseyQualityType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new JerseyQualityTypesModel(await QueryRouter.Send(new GetJerseyQualityTypes()));
    }
}
