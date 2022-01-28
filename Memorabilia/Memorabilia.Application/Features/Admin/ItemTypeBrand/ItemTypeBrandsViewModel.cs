using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
    public class ItemTypeBrandsViewModel : ViewModel
    {
        public ItemTypeBrandsViewModel() { }

        public ItemTypeBrandsViewModel(IEnumerable<Domain.Entities.ItemTypeBrand> itemTypeBrands)
        {
            ItemTypeBrands = itemTypeBrands.Select(ItemTypeBrand => new ItemTypeBrandViewModel(ItemTypeBrand));
        }

        public override string PageTitle => "Item Type Brands";

        public IEnumerable<ItemTypeBrandViewModel> ItemTypeBrands { get; set; } = Enumerable.Empty<ItemTypeBrandViewModel>();
    }
}
