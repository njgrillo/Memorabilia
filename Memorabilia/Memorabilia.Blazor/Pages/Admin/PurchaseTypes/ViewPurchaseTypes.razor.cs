namespace Memorabilia.Blazor.Pages.Admin.PurchaseTypes
{
    public partial class ViewPurchaseTypes 
        : ViewDomainItem<PurchaseTypesModel>
    {
        public async Task OnDelete(DomainEditModel editModel)
        {
            await OnDelete(new SavePurchaseType(editModel));
        }

        protected override async Task OnInitializedAsync()
        {
            Model = new PurchaseTypesModel(await QueryRouter.Send(new GetPurchaseTypes()));
        }
    }
}
