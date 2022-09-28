using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.FirstDayCover
{
    public class FirstDayCoverViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public FirstDayCoverViewModel() { }

        public FirstDayCoverViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
