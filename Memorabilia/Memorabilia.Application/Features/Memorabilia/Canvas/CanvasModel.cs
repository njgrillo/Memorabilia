namespace Memorabilia.Application.Features.Memorabilia.Canvas;

public class CanvasModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public CanvasModel() { }

    public CanvasModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;        

    public int MemorabiliaId 
        => _memorabilia.Id;     

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public Entity.MemorabiliaPicture Picture 
        => _memorabilia.Picture;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams
        => _memorabilia.Teams;
}
