using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class SaveItemTypeSportViewModel : SaveViewModel
{
    public SaveItemTypeSportViewModel() { }

    public SaveItemTypeSportViewModel(ItemTypeSportViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId;
        SportId = viewModel.SportId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeSports.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeSports.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeSports.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
    public int ItemTypeId { get; set; }

    public ItemType[] ItemTypes => ItemType.All;

    public override string RoutePrefix => AdminDomainItem.ItemTypeSports.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }

    public Sport[] Sports => Sport.All;
}
