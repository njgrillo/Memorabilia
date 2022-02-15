using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand
{
    public class ItemTypeBrandsViewModel : ViewModel
    {
        public ItemTypeBrandsViewModel() { }

        public ItemTypeBrandsViewModel(IEnumerable<Domain.Entities.ItemTypeBrand> itemTypeBrands)
        {
            ItemTypeBrands = itemTypeBrands.Select(itemTypeBrand => new ItemTypeBrandViewModel(itemTypeBrand)).ToList();
        }

        public List<ItemTypeBrandViewModel> ItemTypeBrands { get; set; } = new();

        public override string ItemTitle => "Item Type Brand";

        public override string PageTitle => "Item Type Brands";

        public override string RoutePrefix => "ItemTypeBrands";


    }
}
