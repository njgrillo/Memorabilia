namespace Memorabilia.Application.Features.Memorabilia.Bammer;

public class BammerModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BammerModel() { }

    public BammerModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBammer Bammer 
        => _memorabilia.Bammer;

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public Entity.MemorabiliaLevelType Level 
        => _memorabilia.LevelType;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
