using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Helmet
{
    public class HelmetViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public HelmetViewModel() { }

        public HelmetViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaGame MemorabiliaGame => _memorabilia.Game;

        public MemorabiliaHelmet MemorabiliaHelmet => _memorabilia.Helmet;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaLevelType MemorabiliaLevelType => _memorabilia.LevelType;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> MemorabiliaSports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> MemorabiliaTeams => _memorabilia.Teams;

        public MemorabiliaPerson Person => _memorabilia.People.FirstOrDefault();

        public int? PersonId => _memorabilia.People.FirstOrDefault()?.PersonId;        
    }
}
