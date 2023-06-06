using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.IndexCard;

public class IndexCardViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public IndexCardViewModel() { }

    public IndexCardViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public MemorabiliaSize Size => _memorabilia.Size;
}
