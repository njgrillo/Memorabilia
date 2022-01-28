using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSize
{
    public class ItemTypeSizesViewModel : ViewModel
    {
        public ItemTypeSizesViewModel() { }

        public ItemTypeSizesViewModel(IEnumerable<Domain.Entities.ItemTypeSize> itemTypeSizes)
        {
            ItemTypeSizes = itemTypeSizes.Select(ItemTypeSize => new ItemTypeSizeViewModel(ItemTypeSize));
        }

        public override string PageTitle => "Item Type Sizes";

        public IEnumerable<ItemTypeSizeViewModel> ItemTypeSizes { get; set; } = Enumerable.Empty<ItemTypeSizeViewModel>();
    }
}
