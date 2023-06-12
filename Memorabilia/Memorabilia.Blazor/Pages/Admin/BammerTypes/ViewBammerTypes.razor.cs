namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class ViewBammerTypes : ViewDomainItem<BammerTypesModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveBammerType(viewModel));
    }

    public async Task OnLoad()
    {
        ViewModel = new BammerTypesModel(await QueryRouter.Send(new GetBammerTypes()));
    }
}
