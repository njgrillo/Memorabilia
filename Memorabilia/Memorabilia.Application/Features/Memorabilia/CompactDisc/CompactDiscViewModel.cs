using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.CompactDisc
{
    public class CompactDiscViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public CompactDiscViewModel() { }

        public CompactDiscViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;
    }
}
