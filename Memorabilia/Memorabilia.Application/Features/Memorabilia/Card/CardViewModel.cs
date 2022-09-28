using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.Card
{
    public class CardViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public CardViewModel() { }

        public CardViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public MemorabiliaCard Card => _memorabilia.Card;

        public int MemorabiliaId => _memorabilia.Id;        

        public MemorabiliaLevelType Level => _memorabilia.LevelType;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
