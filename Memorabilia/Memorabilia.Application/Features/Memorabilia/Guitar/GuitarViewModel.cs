using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Guitar
{
    public class GuitarViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public GuitarViewModel() { }

        public GuitarViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
    }
}
