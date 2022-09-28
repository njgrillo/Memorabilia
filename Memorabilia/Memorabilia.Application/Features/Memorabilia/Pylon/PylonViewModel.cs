using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Pylon
{
    public class PylonViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public PylonViewModel() { }

        public PylonViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaGame Game => _memorabilia.Game;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaLevelType Level => _memorabilia.LevelType;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
