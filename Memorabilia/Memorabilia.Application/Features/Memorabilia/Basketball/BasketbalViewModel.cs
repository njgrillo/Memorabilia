using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Basketball
{
    public class BasketbalViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BasketbalViewModel() { }

        public BasketbalViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        //public MemorabiliaBasketballType MemorabiliaBasketballType => _memorabilia.BasketballType;

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaCommissioner MemorabiliaCommissioner => _memorabilia.Commissioner;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> MemorabiliaSports => _memorabilia.Sports;

        public int? PersonId => _memorabilia.People.FirstOrDefault()?.PersonId;

        public int? TeamId => _memorabilia.Teams.FirstOrDefault()?.TeamId;
    }
}
