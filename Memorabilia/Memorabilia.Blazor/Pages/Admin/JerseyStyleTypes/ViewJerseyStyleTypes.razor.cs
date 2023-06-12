namespace Memorabilia.Blazor.Pages.Admin.JerseyStyleTypes;

public partial class ViewJerseyStyleTypes 
    : ViewDomainItem<JerseyStyleTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveJerseyStyleType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new JerseyStyleTypesModel(await QueryRouter.Send(new GetJerseyStyleTypes()));
    }
}
