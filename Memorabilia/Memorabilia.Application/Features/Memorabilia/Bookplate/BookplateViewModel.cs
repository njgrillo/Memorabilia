using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Bookplate;

public class BookplateViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public BookplateViewModel() { }

    public BookplateViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
}
