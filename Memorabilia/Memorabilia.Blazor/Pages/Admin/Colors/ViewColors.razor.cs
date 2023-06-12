namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ViewColors 
    : ViewDomainItem<ColorsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveColor(editModel));
    }

    public async Task OnLoad()
    {
        Model = new ColorsModel(await QueryRouter.Send(new GetColors()));
    }
}
