namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class BookplateModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BookplateModel() { }

    public BookplateModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId 
        => _memorabilia.Id;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;
}
