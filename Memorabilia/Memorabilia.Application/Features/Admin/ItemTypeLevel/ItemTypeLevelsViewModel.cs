using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class ItemTypeLevelsViewModel : ViewModel
{
    public ItemTypeLevelsViewModel() { }

    public ItemTypeLevelsViewModel(IEnumerable<Domain.Entities.ItemTypeLevel> itemTypeLevels)
    {
        ItemTypeLevels = itemTypeLevels.Select(itemTypeLevel => new ItemTypeLevelViewModel(itemTypeLevel))
                                       .OrderBy(itemTypeLevel => itemTypeLevel.ItemTypeName)
                                       .ThenBy(itemTypeLevel => itemTypeLevel.LevelTypeName)
                                       .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeLevelViewModel> ItemTypeLevels { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.ItemTypeLevels.Item;

    public override string PageTitle => AdminDomainItem.ItemTypeLevels.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypeLevels.Page;
}
