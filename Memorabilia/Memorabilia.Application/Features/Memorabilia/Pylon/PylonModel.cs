namespace Memorabilia.Application.Features.Memorabilia.Pylon;

public class PylonModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public PylonModel() { }

    public PylonModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public Entity.MemorabiliaLevelType Level 
        => _memorabilia.LevelType;

    public Entity.MemorabiliaSize Size 
        => _memorabilia.Size;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;

    public IEnumerable<Entity.MemorabiliaTeam> Teams 
        => _memorabilia.Teams;
}
