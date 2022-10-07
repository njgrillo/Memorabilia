using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Figure;

public class FigureViewModel
{
    private readonly Domain.Entities.Memorabilia _memorabilia;

    public FigureViewModel() { }

    public FigureViewModel(Domain.Entities.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public MemorabiliaFigure Figure => _memorabilia.Figure;

    public int MemorabiliaId => _memorabilia.Id;        

    public MemorabiliaLevelType Level => _memorabilia.LevelType;

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
