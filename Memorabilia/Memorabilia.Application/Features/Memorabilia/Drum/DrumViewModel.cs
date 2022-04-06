using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Drum
{
    public class DrumViewModel : ViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public DrumViewModel() { }

        public DrumViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
    }
}
