using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes
{
    public class ItemTypeSizesViewModel : ViewModel
    {
        public ItemTypeSizesViewModel() { }

        public ItemTypeSizesViewModel(IEnumerable<ItemTypeSize> itemTypeSizes)
        {
            ItemTypeSizes = itemTypeSizes.Select(itemTypeSize => new ItemTypeSizeViewModel(itemTypeSize)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<ItemTypeSizeViewModel> ItemTypeSizes { get; set; } = new();

        public override string ItemTitle => "Item Type Size";

        public override string PageTitle => "Item Type Sizes";

        public override string RoutePrefix => "ItemTypeSizes";
    }
}
