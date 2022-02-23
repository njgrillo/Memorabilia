using Memorabilia.Domain.Entities;
using System.Collections.Generic;

namespace Memorabilia.Application.Features.Memorabilia.Book
{
    public class BookViewModel
    {
        private readonly Domain.Entities.Memorabilia _memorabilia;

        public BookViewModel() { }

        public BookViewModel(Domain.Entities.Memorabilia memorabilia)
        {
            _memorabilia = memorabilia;
        }

        //public MemorabiliaBook Book => _memorabilia.Book;

        public int MemorabiliaId => _memorabilia.Id;        

        public IEnumerable<MemorabiliaPerson> People => _memorabilia.People;

        public IEnumerable<MemorabiliaSport> Sports => _memorabilia.Sports;

        public IEnumerable<MemorabiliaTeam> Teams => _memorabilia.Teams;
    }
}
