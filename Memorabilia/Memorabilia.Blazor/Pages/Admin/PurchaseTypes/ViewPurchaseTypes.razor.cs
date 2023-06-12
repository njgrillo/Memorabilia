namespace Memorabilia.Blazor.Pages.Admin.PurchaseTypes
{
    public partial class ViewPurchaseTypes 
        : ViewDomainItem<PurchaseTypesModel>, IDeleteDomainItem, IViewDomainItem
    {
        public async Task OnDelete(DomainEditModel editModel)
        {
            await OnDelete(new SavePurchaseType(editModel));
        }

        public async Task OnLoad()
        {
            Model = new PurchaseTypesModel(await QueryRouter.Send(new GetPurchaseTypes()));
        }
    }
}
