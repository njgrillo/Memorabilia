namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class BatModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BatModel() { }

    public BatModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBat Bat 
        => _memorabilia.Bat;

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
