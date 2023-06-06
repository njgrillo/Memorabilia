using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.CerealBox;

public class CerealBoxViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public CerealBoxViewModel() { }

    public CerealBoxViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public MemorabiliaCereal Cereal => _memorabilia.Cereal;

    public int MemorabiliaId => _memorabilia.Id;

    public MemorabiliaLevelType Level => _memorabilia.LevelType;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
