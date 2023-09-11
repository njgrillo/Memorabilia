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

    public int AutographId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Image;

    public bool CanHaveSpot 
        => ItemType?.CanHaveSpot() ?? false;

    public override Constant.EditModeType EditModeType 
        => Images.Any() 
            ? Constant.EditModeType.Update 
            : Constant.EditModeType.Add;

    public List<ImageEditModel> Images { get; set; } 
        = new();

    public Constant.ItemType ItemType { get; }

    public int MemorabiliaId { get; }
}
