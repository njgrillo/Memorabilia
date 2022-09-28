using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Magazine
{
    public class MagazineViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public MagazineViewModel() { }

        public MagazineViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public MemorabiliaMagazine Magazine => _memorabilia.Magazine;

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
