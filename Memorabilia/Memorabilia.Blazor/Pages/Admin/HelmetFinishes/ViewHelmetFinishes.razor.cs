namespace Memorabilia.Blazor.Pages.Admin.HelmetFinishes;

public partial class ViewHelmetFinishes 
    : ViewDomainItem<HelmetFinishesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveHelmetFinish(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new HelmetFinishesModel(await QueryRouter.Send(new GetHelmetFinishes()));
    }
}
