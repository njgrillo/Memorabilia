using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Jersey
{
    public class JerseyViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public JerseyViewModel() { }

        public JerseyViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaGame MemorabiliaGame => _memorabilia.Game;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaJersey MemorabiliaJersey => _memorabilia.Jersey;

        public MemorabiliaLevelType MemorabiliaLevelType => _memorabilia.LevelType;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;        

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
