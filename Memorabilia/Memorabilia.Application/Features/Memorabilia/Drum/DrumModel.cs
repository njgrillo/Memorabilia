namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class DrumModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public DrumModel() { }

    public DrumModel(Entity.Memorabilia memorabilia)
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
