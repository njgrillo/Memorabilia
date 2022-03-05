using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Canvas
{
    public class CanvasViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public CanvasViewModel() { }

        public CanvasViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBrand Brand => _memorabilia.Brand;

        public MemorabiliaCanvas Canvas => _memorabilia.Canvas;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaOrientation Orientation => _memorabilia.Orientation;       

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public MemorabiliaSize Size => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
