using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class JerseyNumberViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public JerseyNumberViewModel() { }

    public JerseyNumberViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public int? Number => _memorabilia.JerseyNumber?.Number ?? null;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
