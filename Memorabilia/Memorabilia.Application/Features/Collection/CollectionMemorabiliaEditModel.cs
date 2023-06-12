namespace Memorabilia.Application.Features.Collection;

public class CollectionMemorabiliaEditModel : EditModel
{
    public CollectionMemorabiliaEditModel() { }

    public CollectionMemorabiliaEditModel(CollectionMemorabiliaModel model)
    {
        CollectionId = model.CollectionId;
        EstimatedValue = model.EstimatedValue ?? 0;
        Id = model.Id;
        ImageDisplayCount = model.ImageDisplayCount;
        ItemTypeName= model.ItemTypeName;
        MemorabiliaId = model.MemorabiliaId;
        MemorabiliaPrimaryImage = model.MemorabiliaPrimaryImage;
        UserId = model.UserId;
    }

    public int CollectionId { get; set; }

    public decimal EstimatedValue { get; }

    public string ItemTypeName { get; set; }

    public int MemorabiliaId { get; set; }

    public string MemorabiliaPrimaryImage { get; }

    public string ImageDisplayCount { get; }

    public int UserId { get; }
}
