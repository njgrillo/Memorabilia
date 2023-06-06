using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Poster;

public class PosterViewModel : Model
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public PosterViewModel() { }

    public PosterViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public int MemorabiliaId => _memorabilia.Id;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaPicture Picture => _memorabilia.Picture;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
