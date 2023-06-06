using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Shirt;

public class ShirtViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public ShirtViewModel() { }

    public ShirtViewModel(Entity.Memorabilia memorabilia)
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

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
