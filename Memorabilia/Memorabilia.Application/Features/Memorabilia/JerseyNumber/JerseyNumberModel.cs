namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class JerseyNumberModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public JerseyNumberModel() { }

    public JerseyNumberModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId 
        => _memorabilia.Id;

    public int? Number 
        => _memorabilia.JerseyNumber?.Number ?? null;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
