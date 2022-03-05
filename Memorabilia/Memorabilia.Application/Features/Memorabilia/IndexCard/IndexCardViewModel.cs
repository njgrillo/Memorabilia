using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Memorabilia.IndexCard
{
    public class IndexCardViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public IndexCardViewModel() { }

        public IndexCardViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaSize Size => _memorabilia.Size;
    }
}
