namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class GuitarModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public GuitarModel() { }

    public GuitarModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBrand Brand 
        => _memorabilia.Brand;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;
}
