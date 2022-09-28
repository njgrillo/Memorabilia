namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle
{
    public class ItemTypeGameStylesViewModel : ViewModel
    {
        public ItemTypeGameStylesViewModel() { }

        public ItemTypeGameStylesViewModel(IEnumerable<Domain.Entities.ItemTypeGameStyleType> itemTypeGameStyles)
        {
            ItemTypeGameStyles = itemTypeGameStyles.Select(itemTypeGameStyle => new ItemTypeGameStyleViewModel(itemTypeGameStyle)).ToList();
        }

        public string AddRoute => $"{RoutePrefix}/Edit/0";

        public string AddTitle => $"Add {ItemTitle}";

        public string ExitNavigationPath => "Admin/EditDomainItems";

        public List<ItemTypeGameStyleViewModel> ItemTypeGameStyles { get; set; } = new();

        public override string ItemTitle => "Item Type Game Style";

        public override string PageTitle => "Item Type Game Styles";

        public override string RoutePrefix => "ItemTypeGameStyles";
    }
}