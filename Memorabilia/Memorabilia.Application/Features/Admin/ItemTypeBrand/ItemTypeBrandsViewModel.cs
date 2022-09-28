namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
    public class ItemTypeBrandsViewModel : ViewModel
    {
        public ItemTypeBrandsViewModel() { }

        public ItemTypeBrandsViewModel(IEnumerable<Domain.Entities.ItemTypeBrand> itemTypeBrands)
        {
            ItemTypeBrands = itemTypeBrands.Select(itemTypeBrand => new ItemTypeBrandViewModel(itemTypeBrand)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<ItemTypeBrandViewModel> ItemTypeBrands { get; set; } = new();

        public override string ItemTitle => "Item Type Brand";

        public override string PageTitle => "Item Type Brands";

        public override string RoutePrefix => "ItemTypeBrands";
    }
}
