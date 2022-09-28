using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.HeadBand
{
    public class HeadBandViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public HeadBandViewModel() { }

        public HeadBandViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public MemorabiliaGame Game => _memorabilia.Game;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaLevelType Level => _memorabilia.LevelType;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
