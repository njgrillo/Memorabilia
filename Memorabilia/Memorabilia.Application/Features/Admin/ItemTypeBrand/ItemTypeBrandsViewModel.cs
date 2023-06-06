using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeBrand;

public class ItemTypeBrandsViewModel : Model
{
    public ItemTypeBrandsViewModel() { }

    public ItemTypeBrandsViewModel(IEnumerable<Domain.Entities.ItemTypeBrand> itemTypeBrands)
    {
        ItemTypeBrands = itemTypeBrands.Select(itemTypeBrand => new ItemTypeBrandViewModel(itemTypeBrand))
                                       .OrderBy(itemTypeBrand => itemTypeBrand.ItemTypeName)
                                       .ThenBy(itemTypeBrand => itemTypeBrand.BrandName)
                                       .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public List<ItemTypeBrandViewModel> ItemTypeBrands { get; set; } = new();

    public override string ItemTitle => AdminDomainItem.ItemTypeBrands.Item;

    public override string PageTitle => AdminDomainItem.ItemTypeBrands.Title;

    public override string RoutePrefix => AdminDomainItem.ItemTypeBrands.Page;
}
