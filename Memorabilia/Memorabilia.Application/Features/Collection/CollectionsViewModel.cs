using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Collection;

public class CollectionsViewModel : ViewModel
{
    public CollectionsViewModel() { }

    public CollectionsViewModel(IEnumerable<Domain.Entities.Collection> collections)
    {
        Collections = collections.Select(collection => new CollectionViewModel(collection)).ToList();
    }

    public string AddRoute => $"{RoutePrefix}/{EditModeType.Update.Name}/0";

    public string AddTitle => $"{EditModeType.Add.Name} {ItemTitle}";

    public override string ExitNavigationPath => "Home";

    public override string ItemTitle => "Collection";

    public override string PageTitle => "Collections";

    public List<CollectionViewModel> Collections { get; set; } = new();

    public override string RoutePrefix => "Collections";
}
