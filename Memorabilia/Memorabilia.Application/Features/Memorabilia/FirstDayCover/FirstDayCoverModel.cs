namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover;

public class FirstDayCoverModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public FirstDayCoverModel() { }

    public FirstDayCoverModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaFirstDayCover FirstDayCover 
        => _memorabilia.FirstDayCover;

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
