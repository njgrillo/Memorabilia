namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class ViewHelmetFinishes 
    : ViewDomainItem<HelmetFinishesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveHelmetFinish(editModel));
    }

    public async Task OnLoad()
    {
        Model = new HelmetFinishesModel(await QueryRouter.Send(new GetHelmetFinishes()));
    }
}
