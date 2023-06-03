using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Collection;

public class CollectionMemorabiliaViewModel
{
    private readonly CollectionMemorabilia _collectionMemorabilia;

    public CollectionMemorabiliaViewModel() { }

    public CollectionMemorabiliaViewModel(CollectionMemorabilia collectionMemorabilia)
    {
        _collectionMemorabilia = collectionMemorabilia;
    }

    public int CollectionId 
        => _collectionMemorabilia.CollectionId;

    public decimal? EstimatedValue 
        => _collectionMemorabilia.Memorabilia.EstimatedValue;

    public int Id 
        => _collectionMemorabilia.Id;

    public string ImageDisplayCount
    {
        get
        {
            if (!_collectionMemorabilia.Memorabilia.Images.Any())
                return "No Images Found";

            if (_collectionMemorabilia.Memorabilia.Images.Count == 1)
                return "1 Image";

            return $"{_collectionMemorabilia.Memorabilia.Images.Count} Images";
        }
    }

    public string ItemTypeName => _collectionMemorabilia.Memorabilia.ItemType?.Name;

    public int MemorabiliaId 
        => _collectionMemorabilia.MemorabiliaId;

    public string MemorabiliaPrimaryImage 
        => !_collectionMemorabilia.Memorabilia.Images.Any()
            ? Domain.Constants.ImageFileName.ImageNotAvailable
            : _collectionMemorabilia.Memorabilia.Images.FirstOrDefault(image => image.ImageTypeId == Domain.Constants.ImageType.Primary.Id)?.FileName 
              ?? _collectionMemorabilia.Memorabilia.Images.First().FileName;

    public int UserId 
        => _collectionMemorabilia.Memorabilia.UserId;
}
