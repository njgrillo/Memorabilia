using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeLevel;

public class SaveItemTypeLevelViewModel : SaveViewModel
{
    public SaveItemTypeLevelViewModel() { }

    public SaveItemTypeLevelViewModel(ItemTypeLevelViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        LevelTypeId = viewModel.LevelTypeId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeLevels.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeLevels.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeLevels.Item;

    public ItemType ItemType { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Level Type is required.")]
    public int LevelTypeId { get; set; }

    public override string RoutePrefix => AdminDomainItem.ItemTypeLevels.Page;
}
