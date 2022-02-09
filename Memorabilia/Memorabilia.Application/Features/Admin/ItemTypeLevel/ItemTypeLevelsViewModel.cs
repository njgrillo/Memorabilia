using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel
{
    public class ItemTypeLevelsViewModel : ViewModel
    {
        public ItemTypeLevelsViewModel() { }

        public ItemTypeLevelsViewModel(IEnumerable<Domain.Entities.ItemTypeLevel> itemTypeLevels)
        {
            ItemTypeLevels = itemTypeLevels.Select(itemTypeLevel => new ItemTypeLevelViewModel(itemTypeLevel));
        }

        public IEnumerable<ItemTypeLevelViewModel> ItemTypeLevels { get; set; } = Enumerable.Empty<ItemTypeLevelViewModel>();

        public override string PageTitle => "Item Type Levels";
    }
}
