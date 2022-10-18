namespace Memorabilia.Blazor.Pages.Admin.PurchaseTypes
{
    public partial class ViewPurchaseTypes : ViewDomainItem<PurchaseTypesViewModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(SaveDomainViewModel viewModel)
        {
            await OnDelete(new SavePurchaseType(viewModel));
        }

        public async Task OnLoad()
        {
            await OnLoad(new GetPurchaseTypes());
        }
    }
}
