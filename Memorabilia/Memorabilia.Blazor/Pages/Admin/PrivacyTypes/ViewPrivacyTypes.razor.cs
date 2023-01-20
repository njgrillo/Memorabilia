namespace Memorabilia.Blazor.Pages.Admin.PrivacyTypes;

public partial class ViewPrivacyTypes : ViewDomainItem<PrivacyTypesViewModel>, IDeleteDomainItem, IViewDomainItem
{
    public async Task OnDelete(SaveDomainViewModel viewModel)
    {
        await OnDelete(new SavePrivacyType(viewModel));
    }

    public async Task OnLoad()
    {
        await OnLoad(new GetPrivacyTypes());
    }
}
