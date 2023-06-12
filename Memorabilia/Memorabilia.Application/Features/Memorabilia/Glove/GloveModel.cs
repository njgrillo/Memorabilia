namespace Memorabilia.Application.Features.Memorabilia.Glove;

public class GloveModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public GloveModel() { }

    public GloveModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

    public Entity.MemorabiliaGlove Glove 
        => _memorabilia.Glove;

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
