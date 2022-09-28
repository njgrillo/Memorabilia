using Memorabilia.Domain.Entities;

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

        public MemorabiliaGame Game => _memorabilia.Game;

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;
    }
}
