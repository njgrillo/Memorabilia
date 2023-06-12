namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class CompactDiscModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public CompactDiscModel() { }

    public CompactDiscModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId 
        => _memorabilia.Id;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;
}
