using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeAuthenticType
{
    public class ItemTypeAuthenticTypesViewModel : ViewModel
    {
        public ItemTypeAuthenticTypesViewModel() { }

        public ItemTypeAuthenticTypesViewModel(IEnumerable<Domain.Entities.ItemTypeAuthenticType> itemTypeAuthenticTypes)
        {
            ItemTypeAuthenticTypes = itemTypeAuthenticTypes.Select(itemTypeAuthenticType => new ItemTypeAuthenticTypeViewModel(itemTypeAuthenticType));
        }

        public IEnumerable<ItemTypeAuthenticTypeViewModel> ItemTypeAuthenticTypes { get; set; } = Enumerable.Empty<ItemTypeAuthenticTypeViewModel>();

        public override string PageTitle => "Item Type Authentic Types";        
    }
}