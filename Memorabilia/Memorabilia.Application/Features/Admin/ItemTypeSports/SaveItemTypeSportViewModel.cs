using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Admin.ItemTypeSports;

public class SaveItemTypeSportViewModel : EditModel
{
    public SaveItemTypeSportViewModel() { }

    public SaveItemTypeSportViewModel(ItemTypeSportViewModel viewModel)
    {
        Id = viewModel.Id;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        SportId = viewModel.SportId;
    }

    public override string ExitNavigationPath => AdminDomainItem.ItemTypeSports.Page;

    public string ImageFileName => AdminDomainItem.ItemTypeSports.ImageFileName;

    public override string ItemTitle => AdminDomainItem.ItemTypeSports.Item;

    public ItemType ItemType { get; set; }

    public override string RoutePrefix => AdminDomainItem.ItemTypeSports.Page;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Sport is required.")]
    public int SportId { get; set; }
}
