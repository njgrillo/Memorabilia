using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Guitar;

public class GuitarViewModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public GuitarViewModel() { }

    public GuitarViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
}
