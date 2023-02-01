namespace Memorabilia.Blazor.Pages.Admin.CerealTypes;

public partial class ViewCerealTypes : ViewDomainItem<CerealTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SaveCerealType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetCerealTypes());
    }
}
