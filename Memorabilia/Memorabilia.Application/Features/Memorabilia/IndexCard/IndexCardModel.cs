namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class IndexCardModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public IndexCardModel() { }

    public IndexCardModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId 
        => _memorabilia.Id;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;
}
