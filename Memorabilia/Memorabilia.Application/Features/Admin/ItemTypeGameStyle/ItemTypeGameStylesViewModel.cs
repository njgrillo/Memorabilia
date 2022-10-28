using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public class ItemTypeGameStylesViewModel : ViewModel
{
    public ItemTypeGameStylesViewModel() { }

    public ItemTypeGameStylesViewModel(IEnumerable<Domain.Entities.ItemTypeGameStyleType> itemTypeGameStyles)
    {
        ItemTypeGameStyles = itemTypeGameStyles.Select(itemTypeGameStyle => new ItemTypeGameStyleViewModel(itemTypeGameStyle))
                                               .OrderBy(itemTypeGameStyleType => itemTypeGameStyleType.ItemTypeName)
                                               .ThenBy(itemTypeGameStyleType => itemTypeGameStyleType.GameStyleTypeName)
                                               .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeGameStyleViewModel> ItemTypeGameStyles { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.ItemTypeGameStyles.Item;

    public override string PageTitle => AdminDomainItem.ItemTypeGameStyles.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypeGameStyles.Page;
}