namespace Memorabilia.Application.Features.Memorabilia.Image;

public class MemorabiliaImagesEditModel : EditModel
{
    public MemorabiliaImagesEditModel() { }

    public MemorabiliaImagesEditModel(MemorabiliaModel model)
    {
        AutographId = model.HasAutographs 
            ? model.Autographs.First().Id 
            : null;

        HasAutographs = model.HasAutographs;
        HasMultipleAutographs = model.AutographsCount > 1;

        Images = model.Images
                      .Select(image => new ImageEditModel(image))
                      .ToList();

        ItemTypeName = model.ItemTypeName;
        MemorabiliaId = model.Id;
    }

    public int? AutographId { get; private set; }

    public override Constant.EditModeType EditModeType 
        => Images.Any() ? Constant.EditModeType.Update : Constant.EditModeType.Add;

    public bool HasAutographs { get; private set; }

    public bool HasMultipleAutographs { get; private set; }

    public List<ImageEditModel> Images { get; set; } 
        = new();

    public string ItemTypeName { get; }

    public int MemorabiliaId { get; set; }

    public Constant.MemorabiliaItemStep MemorabiliaItemStep
        => Constant.MemorabiliaItemStep.Image;
}
