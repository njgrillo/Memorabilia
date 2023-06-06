using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.TennisRacket;

public class TennisRacketViewModel : Model
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public TennisRacketViewModel() { }

    public TennisRacketViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public MemorabiliaGame Game => _memorabilia.Game;

    public int MemorabiliaId => _memorabilia.Id;

    public MemorabiliaLevelType Level => _memorabilia.LevelType;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public object Teams { get; internal set; }
}
