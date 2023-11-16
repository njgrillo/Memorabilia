namespace Memorabilia.Application.Features.Collection;

public class CollectionsModel : Model
{
    public CollectionsModel() { }

    public CollectionsModel(IEnumerable<Entity.Collection> collections)
    {
        Collections = collections.Select(collection => new CollectionModel(collection))
                                 .ToList();
    }

    public List<CollectionModel> Collections { get; set; } 
        = [];
}
