namespace Memorabilia.Blazor.Pages.Admin.BammerTypes;

public partial class ViewBammerTypes : ViewDomainItem<BammerTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(DomainEditModel viewModel)
    {
        await OnDelete(new SaveBammerType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetBammerTypes());
    }
}
