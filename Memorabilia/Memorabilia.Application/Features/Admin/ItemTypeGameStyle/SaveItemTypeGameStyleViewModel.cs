using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeGameStyle;

public class SaveItemTypeGameStyleViewModel : SaveViewModel
{
    public SaveItemTypeGameStyleViewModel() { }

    public SaveItemTypeGameStyleViewModel(ItemTypeGameStyleViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        GameStyleTypeId = viewModel.GameStyleTypeId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeGameStyles.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Game Style Type is required.")]
    public int GameStyleTypeId { get; set; }

    public string ImageFileName => AdminDomainItem.ItemTypeGameStyles.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeGameStyles.Item;

    public ItemType ItemType { get; set; }

    public override string RoutePrefix => AdminDomainItem.ItemTypeGameStyles.Page;
}
