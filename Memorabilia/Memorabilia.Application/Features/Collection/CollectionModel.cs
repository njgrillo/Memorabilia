namespace Memorabilia.Application.Features.Collection;

public class CollectionModel
{
    private readonly Entity.Collection _collection;

    public CollectionModel() { }

    public CollectionModel(Entity.Collection collection)
    {
        _collection = collection;
    }

    public string Description => _collection.Description;

    public int Id => _collection.Id;

    public List<Entity.CollectionMemorabilia> Memorabilia 
        => _collection.Memorabilia;

    public string Name => _collection.Name;

    public int UserId => _collection.UserId;
}
