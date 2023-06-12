namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class ViewJerseyStyleTypes 
    : ViewDomainItem<JerseyStyleTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveJerseyStyleType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new JerseyStyleTypesModel(await QueryRouter.Send(new GetJerseyStyleTypes()));
    }
}
