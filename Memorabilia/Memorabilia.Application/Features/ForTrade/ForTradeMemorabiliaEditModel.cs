namespace Memorabilia.Application.Features.ForTrade;

public class ForTradeMemorabiliaEditModel : EditModel
{
    public ForTradeMemorabiliaEditModel() { }

    public ForTradeMemorabiliaEditModel(ForTradeMemorabiliaModel model)
    {
        Id = model.Id;
        ImageDisplayCount = model.ImageDisplayCount;
        ItemTypeName = model.ItemTypeName;
        MemorabiliaPrimaryImage = model.MemorabiliaPrimaryImage;
        UserId = model.UserId;
    }

    public bool IsSelected { get; set; }

    public string ItemTypeName { get; set; }

    public string MemorabiliaPrimaryImage { get; }

    public string ImageDisplayCount { get; }

    public int UserId { get; }
}
