namespace Memorabilia.Application.Features.Memorabilia.Football;

public class FootballModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public FootballModel() { }

    public FootballModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }        

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public Entity.MemorabiliaCommissioner Commissioner 
        => _memorabilia.Commissioner;

    public Entity.MemorabiliaFootball Football 
        => _memorabilia.Football;

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

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
