namespace Memorabilia.Blazor.Pages.Admin.Colors;

public partial class ViewColors 
    : ViewDomainItem<ColorsModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveColor(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new ColorsModel(await QueryRouter.Send(new GetColors()));
    }
}
