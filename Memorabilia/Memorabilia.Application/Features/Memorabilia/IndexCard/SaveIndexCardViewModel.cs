using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class SaveIndexCardViewModel : MemorabiliaItemEditViewModel
{
    public SaveIndexCardViewModel() 
    { 
        SizeId = Size.ThreeByFive.Id;
    }

    public SaveIndexCardViewModel(IndexCardViewModel viewModel)
    {
        MemorabiliaId = viewModel.MemorabiliaId;
        SizeId = viewModel.Size.SizeId;
    }

    public override string ImageFileName => Constant.ImageFileName.IndexCard;

    public override ItemType ItemType => ItemType.IndexCard;
}
