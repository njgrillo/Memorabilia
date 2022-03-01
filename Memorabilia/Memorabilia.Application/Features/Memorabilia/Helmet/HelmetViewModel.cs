using Memorabilia.Domain.Entities;
using System.Collections.Generic;

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

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public MemorabiliaGame Game => _memorabilia.Game;

        public MemorabiliaHelmet Helmet => _memorabilia.Helmet;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaLevelType Level => _memorabilia.LevelType;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;   
    }
}
