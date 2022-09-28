using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports
{
    public class ItemTypeSportsViewModel : ViewModel
    {
        public ItemTypeSportsViewModel() { }

        public ItemTypeSportsViewModel(IEnumerable<ItemTypeSport> itemTypeSports)
        {
            ItemTypeSports = itemTypeSports.Select(itemTypeSport => new ItemTypeSportViewModel(itemTypeSport)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<ItemTypeSportViewModel> ItemTypeSports { get; set; } = new();

        public override string ItemTitle => "Item Type Sport";

        public override string PageTitle => "Item Type Sports";

        public override string RoutePrefix => "ItemTypeSports";
    }
}
