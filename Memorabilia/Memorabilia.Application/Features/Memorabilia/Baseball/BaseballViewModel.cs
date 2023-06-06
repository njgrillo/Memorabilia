using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Baseball;

public class BaseballViewModel : Model
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public BaseballViewModel() { }

    public BaseballViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBaseball Baseball => _memorabilia.Baseball;

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public MemorabiliaCommissioner Commissioner => _memorabilia.Commissioner;

    public MemorabiliaGame Game => _memorabilia.Game;

    public int MemorabiliaId => _memorabilia.Id;

    public MemorabiliaLevelType Level => _memorabilia.LevelType;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
