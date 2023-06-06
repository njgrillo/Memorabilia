namespace Memorabilia.Application.Features.Memorabilia;

public class SelectMemorabiliaItemModel
{
    public SelectMemorabiliaItemModel() { }

    public SelectMemorabiliaItemModel(Entity.Memorabilia memorabilia)
    {
        Autographs = memorabilia.Autographs
                                .Select(autograph => new AutographModel(autograph));
    }

    public IEnumerable<AutographModel> Autographs { get; private set; } 
        = Enumerable.Empty<AutographModel>();
}
