namespace Memorabilia.Application.Features.Memorabilia.Ticket;

public class TicketModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public TicketModel() { }

    public TicketModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

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
