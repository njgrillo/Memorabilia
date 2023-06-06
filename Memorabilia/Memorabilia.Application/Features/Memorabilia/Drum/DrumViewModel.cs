using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Drum;

public class DrumViewModel : Model
{
    private readonly Entity.Memorabilia _memorabilia;

    public DrumViewModel() { }

    public DrumViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
}
