namespace Memorabilia.Application.Features.Memorabilia.PinFlag;

public class PinFlagModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public PinFlagModel() { }

    public PinFlagModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public Entity.MemorabiliaGame Game 
        => _memorabilia.Game;

    public int MemorabiliaId 
        => _memorabilia.Id;

    public IEnumerable<Entity.MemorabiliaPerson> People 
        => _memorabilia.People;

    public IEnumerable<Entity.MemorabiliaSport> Sports 
        => _memorabilia.Sports;
}
