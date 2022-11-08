using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class SaveIndexCardViewModel : SaveItemViewModel
{
    public SaveIndexCardViewModel() { }

    public SaveIndexCardViewModel(IndexCardViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
    }

    public override string BackNavigationPath => $"Memorabilia/{EditModeType.Update.Name}/{MemorabiliaId}";

    public override EditModeType EditModeType => MemorabiliaId > 0 ? EditModeType.Update : EditModeType.Add;

    public override string ExitNavigationPath => "Memorabilia/Items";

    public override string ImageFileName => Domain.Constants.ImageFileName.IndexCard;

    public override ItemType ItemType => ItemType.IndexCard;
   
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Size is required.")]
    public int SizeId { get; set; } = Size.ThreeByFive.Id;
}
