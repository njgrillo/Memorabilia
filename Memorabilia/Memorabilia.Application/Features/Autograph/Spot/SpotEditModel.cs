namespace Memorabilia.Application.Features.Autograph.Spot;

public class SpotEditModel : EditModel
{
    public SpotEditModel() { }

    public SpotEditModel(SpotModel viewModel)
    {
        AutographId = viewModel.AutographId;
        ItemType = Constant.ItemType.Find(viewModel.ItemTypeId);
        MemorabiliaId = viewModel.MemorabiliaId;
        MemorabiliaImageNames = viewModel.MemorabiliaImageNames;
        SpotId = viewModel.SpotId;
        UserId = viewModel.UserId;
    }

    public int AutographId { get; set; }

    public Constant.AutographStep AutographStep 
        => Constant.AutographStep.Spot;

    public override string BackNavigationPath
        => $"Autographs/Authentications/{Constant.EditModeType.Update.Name}/{AutographId}";

    public bool CanHaveSpot 
        => ItemType?.CanHaveSpot() ?? false;

    public override string ContinueNavigationPath 
        => $"Autographs/Image/{Constant.EditModeType.Update.Name}/{AutographId}";

    public override Constant.EditModeType EditModeType 
        => SpotId > 0 ? Constant.EditModeType.Update : Constant.EditModeType.Add;

    public override string ExitNavigationPath 
        => "Memorabilia/View";

    public bool HasMemorabiliaImages
        => MemorabiliaImageNames.Any();

    public virtual string ImageFileName 
        => Constant.AdminDomainItem.Spots.ImageFileName;

    public Constant.ItemType ItemType { get; set; }

    public string ItemTypeName 
        => ItemType?.Name;

    public int MemorabiliaId { get; }

    public string[] MemorabiliaImageNames { get; } = Array.Empty<string>();

    public override string PageTitle 
        => $"{(EditModeType == Constant.EditModeType.Add ? Constant.EditModeType.Add.Name : Constant.EditModeType.Update.Name)} Spot";

    public int SpotId { get; set; }

    public int UserId { get; }
}
