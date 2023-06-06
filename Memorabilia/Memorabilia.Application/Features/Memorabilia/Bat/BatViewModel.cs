using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Bat;

public class BatViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BatViewModel() { }

    public BatViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBat Bat => _memorabilia.Bat;

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public MemorabiliaGame Game => _memorabilia.Game;

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
