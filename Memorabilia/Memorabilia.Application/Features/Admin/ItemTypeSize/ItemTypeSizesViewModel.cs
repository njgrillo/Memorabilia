using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSize
{
    public class ItemTypeSizesViewModel : ViewModel
    {
        public ItemTypeSizesViewModel() { }

        public ItemTypeSizesViewModel(IEnumerable<Domain.Entities.ItemTypeSize> itemTypeSizes)
        {
            ItemTypeSizes = itemTypeSizes.Select(itemTypeSize => new ItemTypeSizeViewModel(itemTypeSize)).ToList();
        }

        public List<ItemTypeSizeViewModel> ItemTypeSizes { get; set; } = new();

        public override string ItemTitle => "Item Type Size";

        public override string PageTitle => "Item Type Sizes";

        public override string RoutePrefix => "ItemTypeSizes";
    }
}
