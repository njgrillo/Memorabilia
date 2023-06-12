namespace Memorabilia.Blazor.Pages.Admin.HelmetTypes;

public partial class ViewHelmetTypes 
    : ViewDomainItem<HelmetTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel editModel)
    {
        await CommandRouter.Send(new SaveHelmetType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new HelmetTypesModel(await QueryRouter.Send(new GetHelmetTypes()));
    }
}
