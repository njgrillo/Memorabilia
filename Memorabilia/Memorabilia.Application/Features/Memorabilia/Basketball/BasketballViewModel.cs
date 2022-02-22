using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Basketball
{
    public class BasketballViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BasketballViewModel() { }

        public BasketballViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBasketball MemorabiliaBasketball => _memorabilia.Basketball;

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaCommissioner MemorabiliaCommissioner => _memorabilia.Commissioner;

        public MemorabiliaGame MemorabiliaGame => _memorabilia.Game;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaLevelType MemorabiliaLevelType => _memorabilia.LevelType;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> MemorabiliaSports => _memorabilia.Sports;

        public MemorabiliaPerson Person => _memorabilia.People.FirstOrDefault();

        public int? PersonId => _memorabilia.People.FirstOrDefault()?.PersonId;

        public int? TeamId => _memorabilia.Teams.FirstOrDefault()?.TeamId;
    }
}
