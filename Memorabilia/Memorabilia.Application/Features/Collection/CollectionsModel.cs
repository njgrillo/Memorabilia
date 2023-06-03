using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Collection;

public class CollectionsModel : ViewModel
{
    public CollectionsModel() { }

    public CollectionsModel(IEnumerable<Domain.Entities.Collection> collections)
    {
        Collections = collections.Select(collection => new CollectionModel(collection))
                                 .ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ExitNavigationPath => "Home";

    public override string ItemTitle => "Collection";

    public override string PageTitle => "Collections";

    public List<CollectionModel> Collections { get; set; } = new();

    public override string RoutePrefix => "Collections";
}
