namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class BasketballModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BasketballModel() { }

    public BasketballModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBasketball Basketball
        => _memorabilia.Basketball;

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public Entity.MemorabiliaCommissioner Commissioner 
        => _memorabilia.Commissioner;

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public Entity.MemorabiliaLevelType Level 
        => _memorabilia.LevelType;        

    public List<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public List<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
