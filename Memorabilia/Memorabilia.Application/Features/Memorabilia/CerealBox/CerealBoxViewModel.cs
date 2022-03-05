using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.CerealBox
{
    public class CerealBoxViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public CerealBoxViewModel() { }

        public CerealBoxViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaLevelType Level => _memorabilia.LevelType;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
