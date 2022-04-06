using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.PinFlag
{
    public class PinFlagViewModel : ViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public PinFlagViewModel() { }

        public PinFlagViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;
    }
}
