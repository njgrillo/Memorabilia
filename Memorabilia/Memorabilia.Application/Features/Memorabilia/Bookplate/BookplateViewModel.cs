using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Bookplate
{
    public class BookplateViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BookplateViewModel() { }

        public BookplateViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
    }
}
