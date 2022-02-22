using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Football
{
    public class FootballViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public FootballViewModel() { }

        public FootballViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }        

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaCommissioner MemorabiliaCommissioner => _memorabilia.Commissioner;

        public MemorabiliaFootball MemorabiliaFootball => _memorabilia.Football;

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
