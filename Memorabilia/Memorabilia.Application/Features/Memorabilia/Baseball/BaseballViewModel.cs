using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Baseball
{
    public class BaseballViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BaseballViewModel() { }

        public BaseballViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBaseballType MemorabiliaBaseballType => _memorabilia.BaseballType;

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaCommissioner MemorabiliaCommissioner => _memorabilia.Commissioner;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> MemorabiliaSports => _memorabilia.Sports; 

        public int? PersonId => _memorabilia.People.FirstOrDefault()?.PersonId;

        public int? TeamId => _memorabilia.Teams.FirstOrDefault()?.TeamId;
    }
}
