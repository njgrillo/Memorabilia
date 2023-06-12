namespace Memorabilia.Blazor.Pages.Admin.BatTypes;

public partial class ViewBatTypes 
    : ViewDomainItem<BatTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await CommandRouter.Send(new SaveBatType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new BatTypesModel(await QueryRouter.Send(new GetBatTypes()));
    }
}
