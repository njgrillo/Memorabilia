using Memorabilia.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Memorabilia.Application.Features.Memorabilia.Bat
{
    public class BatViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BatViewModel() { }

        public BatViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        public MemorabiliaBat MemorabiliaBat => _memorabilia.Bat;

        public MemorabiliaBrand MemorabiliaBrand => _memorabilia.Brand;

        public MemorabiliaGame MemorabiliaGame => _memorabilia.Game;

        public int MemorabiliaId => _memorabilia.Id;

        public MemorabiliaSize MemorabiliaSize => _memorabilia.Size;

        public IEnumerable<MemorabiliaSport> MemorabiliaSports => _memorabilia.Sports;

        public MemorabiliaPerson Person => _memorabilia.People.FirstOrDefault();

        public int? PersonId => _memorabilia.People.FirstOrDefault()?.PersonId;

        public int? TeamId => _memorabilia.Teams.FirstOrDefault()?.TeamId;
    }
}
