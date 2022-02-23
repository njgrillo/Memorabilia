using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.JerseyNumber
{
    public class JerseyNumberViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public JerseyNumberViewModel() { }

        public JerseyNumberViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
