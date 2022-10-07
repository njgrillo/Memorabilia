using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class SaveItemTypeLevelViewModel : SaveViewModel
{
    public SaveItemTypeLevelViewModel() { }

    public SaveItemTypeLevelViewModel(ItemTypeLevelViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemTypeId = viewModel.ItemTypeId;
        LevelTypeId = viewModel.LevelTypeId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeLevels.Page;

    public string ImagePath => AdminDomainItem.ItemTypeLevels.ImagePath;

    public override string ItemTitle => AdminDomainItem.ItemTypeLevels.Item;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Item Type is required.")]
    public int ItemTypeId { get; set; }

    public ItemType[] ItemTypes => ItemType.All;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
    public int LevelTypeId { get; set; }

    public LevelType[] LevelTypes => LevelType.All;

    public override string RoutePrefix => AdminDomainItem.ItemTypeLevels.Page;
}
