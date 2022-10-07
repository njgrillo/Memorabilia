using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber;

public class JerseyNumberViewModel
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public JerseyNumberViewModel() { }

    public JerseyNumberViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
