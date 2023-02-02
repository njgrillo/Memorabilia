using Memorabilia.Domain.Constants;
using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Autograph.Image;

public class SaveAutographImagesViewModel : SaveViewModel
{
    public SaveAutographImagesViewModel() { }

    public SaveAutographImagesViewModel(List<AutographImage> images, 
                                        Domain.Constants.ItemType itemType, 
                                        int memorabiliaId,
                                        int autographId)
    {
        Images = images.Select(image => new SaveImageViewModel(image)).ToList();
        ItemType = itemType;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
    }

    [Required]
    public int AutographId { get; set; }

    public AutographStep AutographStep => AutographStep.Image;

    public override string BackNavigationPath => CanHaveSpot 
        ? $"Autographs/{AdminDomainItem.Spots.Item}/{EditModeType.Update.Name}/{AutographId}" 
        : $"Autographs/Authentications/{EditModeType.Update.Name}/{AutographId}";

    public bool CanHaveSpot => Domain.Constants.ItemType.CanHaveSpot(ItemType);

    public override string ContinueNavigationPath 
        => $"Autographs/{EditModeType.Update.Name}/{MemorabiliaId}/-1";

    public override EditModeType EditModeType => Images.Any() ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public List<SaveImageViewModel> Images { get; set; } = new();

    public Domain.Constants.ItemType ItemType { get; }

    public int MemorabiliaId { get; }

    public override string PageTitle 
        => $"{(EditModeType == EditModeType.Add ? EditModeType.Add.Name : EditModeType.Update.Name)} Image(s)";
}
