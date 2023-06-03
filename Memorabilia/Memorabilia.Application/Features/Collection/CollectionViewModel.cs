using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Collection;

public class CollectionViewModel
{
    private readonly Domain.Entities.Collection _collection;

    public CollectionViewModel() { }

    public CollectionViewModel(Domain.Entities.Collection collection)
    {
        _collection = collection;
    }

    public string Description => _collection.Description;

    public int Id => _collection.Id;

    public List<CollectionMemorabilia> Memorabilia => _collection.Memorabilia;

    public string Name => _collection.Name;

    public int UserId => _collection.UserId;
}
