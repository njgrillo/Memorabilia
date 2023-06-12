namespace Memorabilia.Application.Features.Memorabilia.Bobblehead;

public class BobbleheadModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BobbleheadModel() { }

    public BobbleheadModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBobblehead Bobblehead 
        => _memorabilia.Bobblehead;

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

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

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
