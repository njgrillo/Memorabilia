using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Trunks;

public class TrunkViewModel : Model
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public TrunkViewModel() { }

    public TrunkViewModel(Domain.Entities.Memorabilia memorabilia)
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
}
