using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class ItemTypeSportsViewModel : ViewModel
    {
        public ItemTypeSportsViewModel() { }

        public ItemTypeSportsViewModel(IEnumerable<Domain.Entities.ItemTypeSport> itemTypeSports)
        {
            ItemTypeSports = itemTypeSports.Select(ItemTypeSport => new ItemTypeSportViewModel(ItemTypeSport));
        }

        public IEnumerable<ItemTypeSportViewModel> ItemTypeSports { get; set; } = Enumerable.Empty<ItemTypeSportViewModel>();

        public override string PageTitle => "Item Type Sports";        
    }
}
