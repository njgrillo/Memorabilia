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

    public string AutographNavigationPath 
        => $"Autographs/{Constant.EditModeType.Update.Name}/{MemorabiliaId}/{(AutographId.HasValue ? AutographId : "-1")}";

    public override string BackNavigationPath 
        => $"Memorabilia/{ItemTypeName}/{Constant.EditModeType.Update.Name}/{MemorabiliaId}";

    public override string ContinueNavigationPath 
        => $"Autographs/{Constant.EditModeType.Update.Name}/{MemorabiliaId}/-1";

    public override Constant.EditModeType EditModeType 
        => Images.Any() ? Constant.EditModeType.Update : Constant.EditModeType.Add;

    public override string ExitNavigationPath
        => "Memorabilia/View";

    public bool HasAutographs { get; private set; }

    public bool HasMultipleAutographs { get; private set; }

    public List<ImageEditModel> Images { get; set; } 
        = new();

    public string ItemTypeName { get; }

    public int MemorabiliaId { get; set; }

    public Constant.MemorabiliaItemStep MemorabiliaItemStep
        => Constant.MemorabiliaItemStep.Image;

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Add ? Constant.EditModeType.Add.Name : Constant.EditModeType.Update.Name)} Memorabilia Image(s)";
}
