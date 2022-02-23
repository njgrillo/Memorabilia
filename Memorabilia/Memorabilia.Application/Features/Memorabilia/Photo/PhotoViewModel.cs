using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Photo
{
    public class PhotoViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public PhotoViewModel() { }

        public PhotoViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaOrientation Orientation => _memorabilia.Orientation;

        public MemorabiliaPhoto Photo => _memorabilia.Photo;

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
