using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ItemTypeSizes;

public class ItemTypeSizesViewModel : Model
{
    public ItemTypeSizesViewModel() { }

    public ItemTypeSizesViewModel(IEnumerable<ItemTypeSize> itemTypeSizes)
    {
        ItemTypeSizes = itemTypeSizes.Select(itemTypeSize => new ItemTypeSizeViewModel(itemTypeSize))
                                     .OrderBy(itemTypeSize => itemTypeSize.ItemTypeName)
                                     .ThenBy(itemTypeSize => itemTypeSize.SizeName)
                                     .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeSizeViewModel> ItemTypeSizes { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.ItemTypeSizes.Item;

    public override string PageTitle => AdminDomainItem.ItemTypeSizes.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypeSizes.Page;
}
