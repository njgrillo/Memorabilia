namespace Memorabilia.Application.Features.Memorabilia.Trunks;

public class TrunkModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public TrunkModel() { }

    public TrunkModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public Entity.MemorabiliaLevelType Level 
        => _memorabilia.LevelType;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;
}
