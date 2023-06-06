using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.CompactDisc;

public class CompactDiscViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public CompactDiscViewModel() { }

    public CompactDiscViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
}
