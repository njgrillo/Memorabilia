using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Basketball;

public class BasketballViewModel
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public BasketballViewModel() { }

    public BasketballViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBasketball Basketball => _memorabilia.Basketball;

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public MemorabiliaCommissioner Commissioner => _memorabilia.Commissioner;

    public MemorabiliaGame Game => _memorabilia.Game;

    public int MemorabiliaId => _memorabilia.Id;

    public MemorabiliaLevelType Level => _memorabilia.LevelType;        

    public List<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public List<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
