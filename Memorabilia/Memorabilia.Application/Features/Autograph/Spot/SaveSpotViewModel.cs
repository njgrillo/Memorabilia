using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Autograph.Spot;

public class SaveSpotViewModel : SaveViewModel
{
    public SaveSpotViewModel() { }

    public SaveSpotViewModel(SpotViewModel viewModel)
    {
        AutographId = viewModel.AutographId;
        ItemType = ItemType.Find(viewModel.ItemTypeId);
        MemorabiliaId = viewModel.MemorabiliaId;
        MemorabiliaImageNames = viewModel.MemorabiliaImageNames;
        SpotId = viewModel.SpotId;
    }

    public int AutographId { get; set; }

    public AutographStep AutographStep 
        => AutographStep.Spot;

    public override string BackNavigationPath
        => $"Autographs/Authentications/{EditModeType.Update.Name}/{AutographId}";

    public bool CanHaveSpot 
        => ItemType?.CanHaveSpot() ?? false;

    public override string ContinueNavigationPath 
        => $"Autographs/Image/{EditModeType.Update.Name}/{AutographId}";

    public override EditModeType EditModeType 
        => SpotId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath 
        => "Memorabilia/Items";

    public bool HasMemorabiliaImages
        => MemorabiliaImageNames.Any();

    public virtual string ImageFileName 
        => AdminDomainItem.Spots.ImageFileName;

    public ItemType ItemType { get; set; }

    public string ItemTypeName 
        => ItemType?.Name;

    public int MemorabiliaId { get; }

    public string[] MemorabiliaImageNames { get; } = Array.Empty<string>();

    public override string PageTitle 
        => $"{(EditModeType == EditModeType.Add ? EditModeType.Add.Name : EditModeType.Update.Name)} Spot";

    public int SpotId { get; set; }
}
