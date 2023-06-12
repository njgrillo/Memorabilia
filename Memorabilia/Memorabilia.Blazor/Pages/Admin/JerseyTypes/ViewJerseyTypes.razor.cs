namespace Memorabilia.Blazor.Pages.Admin.JerseyTypes;

public partial class ViewJerseyTypes 
    : ViewDomainItem<JerseyTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveJerseyType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new JerseyTypesModel(await QueryRouter.Send(new GetJerseyTypes()));
    }
}
