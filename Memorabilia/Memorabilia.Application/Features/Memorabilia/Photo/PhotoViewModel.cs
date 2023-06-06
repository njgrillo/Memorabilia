using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Photo;

public class PhotoViewModel
{
    private readonly Entity.Memorabilia _memorabilia;

    public PhotoViewModel() { }

    public PhotoViewModel(Entity.Memorabilia memorabilia)
    {
        _memorabilia = memorabilia;
    }

    public MemorabiliaBrand Brand => _memorabilia.Brand;

    public int MemorabiliaId => _memorabilia.Id;      

    public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

    public MemorabiliaPicture Picture => _memorabilia.Picture;

    public MemorabiliaSize Size => _memorabilia.Size;

    public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

    public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
}
