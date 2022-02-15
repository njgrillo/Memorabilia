using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Admin.ItemTypeSport
{
    public class ItemTypeSportsViewModel : ViewModel
    {
        public ItemTypeSportsViewModel() { }

        public ItemTypeSportsViewModel(IEnumerable<Domain.Entities.ItemTypeSport> itemTypeSports)
        {
            ItemTypeSports = itemTypeSports.Select(itemTypeSport => new ItemTypeSportViewModel(itemTypeSport)).ToList();
        }

        public List<ItemTypeSportViewModel> ItemTypeSports { get; set; } = new();

        public override string ItemTitle => "Item Type Sport";

        public override string PageTitle => "Item Type Sports";

        public override string RoutePrefix => "ItemTypeSports";
    }
}
