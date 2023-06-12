namespace Memorabilia.Application.Features.Autograph.Image;

public class AutographImagesEditModel : EditModel
{
    public AutographImagesEditModel() { }

    public AutographImagesEditModel(List<Entity.AutographImage> images, 
                                    Constant.ItemType itemType, 
                                    int memorabiliaId,
                                    int autographId)
    {
        Images = images.Select(image => new ImageEditModel(image))
                       .ToList();

        ItemType = itemType;
        MemorabiliaId = memorabiliaId;
        AutographId = autographId;
    }

    [Required]
    public int AutographId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Image;

    public override string BackNavigationPath 
        => CanHaveSpot 
        ? $"Autographs/{Constant.AdminDomainItem.Spots.Item}/{Constant.EditModeType.Update.Name}/{AutographId}" 
        : $"Autographs/Authentications/{Constant.EditModeType.Update.Name}/{AutographId}";

    public bool CanHaveSpot 
        => ItemType?.CanHaveSpot() ?? false;

    public override string ContinueNavigationPath 
        => $"Autographs/{Constant.EditModeType.Update.Name}/{MemorabiliaId}/-1";

    public override Constant.EditModeType EditModeType 
        => Images.Any() ? Constant.EditModeType.Update : Constant.EditModeType.Add;

    public override string ExitNavigationPath 
        => "Memorabilia/View";

    public List<ImageEditModel> Images { get; set; } 
        = new();

    public Constant.ItemType ItemType { get; }

    public int MemorabiliaId { get; }

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Add 
                ? Constant.EditModeType.Add.Name 
                : Constant.EditModeType.Update.Name)} Image(s)";
}
