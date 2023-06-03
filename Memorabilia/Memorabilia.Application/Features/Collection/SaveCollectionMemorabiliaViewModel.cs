namespace Memorabilia.Application.Features.Collection;

public class SaveCollectionMemorabiliaViewModel : SaveViewModel
{
    public SaveCollectionMemorabiliaViewModel() { }

    public SaveCollectionMemorabiliaViewModel(CollectionMemorabiliaViewModel viewModel)
    {
        CollectionId = viewModel.CollectionId;
        EstimatedValue = viewModel.EstimatedValue ?? 0;
        Id = viewModel.Id;
        ImageDisplayCount = viewModel.ImageDisplayCount;
        ItemTypeName= viewModel.ItemTypeName;
        MemorabiliaId = viewModel.MemorabiliaId;
        MemorabiliaPrimaryImage = viewModel.MemorabiliaPrimaryImage;
        UserId = viewModel.UserId;
    }

    public int CollectionId { get; set; }

    public decimal EstimatedValue { get; }

    public string ItemTypeName { get; set; }

    public int MemorabiliaId { get; set; }

    public string MemorabiliaPrimaryImage { get; }

    public string ImageDisplayCount { get; }

    public int UserId { get; }
}
