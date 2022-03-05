using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Lithograph
{
    public class LithographViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public LithographViewModel() { }

        public LithographViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public MemorabiliaLithograph Lithograph => _memorabilia.Lithograph;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaOrientation Orientation => _memorabilia.Orientation;        

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
