namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class IndexCardEditModel : MemorabiliaItemEditModel
{
    public IndexCardEditModel() 
    { 
        SizeId = Constant.Size.ThreeByFive.Id;
    }

    public IndexCardEditModel(IndexCardModel model)
    {
        MemorabiliaId = model.MemorabiliaId;
        SizeId = model.Size.SizeId;
    }

    public override string ImageFileName 
        => Constant.ImageFileName.IndexCard;

    public override Constant.ItemType ItemType 
        => Constant.ItemType.IndexCard;
}
