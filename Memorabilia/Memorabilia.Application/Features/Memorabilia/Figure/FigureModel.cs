namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class FigureModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public FigureModel() { }

    public FigureModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public Entity.MemorabiliaFigure Figure 
        => _memorabilia.Figure;

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
