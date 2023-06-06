namespace Memorabilia.Application.Features.Collection;

public class CollectionsModel : Model
{
    public CollectionsModel() { }

    public CollectionsModel(IEnumerable<Entity.Collection> collections)
    {
        Collections = collections.Select(collection => new CollectionModel(collection))
                                 .ToList();
    }

    public string AddRoute 
        => $"{RoutePrefix}/{Constant.EditModeType.Update.Name}/0";

    public string AddTitle 
        => $"{Constant.EditModeType.Add.Name} {ItemTitle}";

    public override string ExitNavigationPath => "Home";

    public override string ItemTitle => "Collection";

    public override string PageTitle => "Collections";

    public List<CollectionModel> Collections { get; set; } = new();

    public override string RoutePrefix => "Collections";
}
