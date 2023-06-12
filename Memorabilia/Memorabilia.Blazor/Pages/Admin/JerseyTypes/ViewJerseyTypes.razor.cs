namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class ViewJerseyTypes 
    : ViewDomainItem<JerseyTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveJerseyType(editModel));
    }

    public async Task OnLoad()
    {
        Model = new JerseyTypesModel(await QueryRouter.Send(new GetJerseyTypes()));
    }
}
