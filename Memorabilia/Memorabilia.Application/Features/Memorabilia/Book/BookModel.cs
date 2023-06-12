namespace Memorabilia.Application.Features.Memorabilia.Book;

public class BookModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BookModel() { }

    public BookModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaBook Book 
        => _memorabilia.Book;

    public int MemorabiliaId 
        => _memorabilia.Id;        

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
