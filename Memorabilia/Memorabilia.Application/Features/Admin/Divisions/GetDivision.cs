using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Divisions
{
    public class GetDivision
    {
        public class Handler : QueryHandler<Query, DivisionViewModel>
        {
            private readonly IDivisionRepository _divisionRepository;

            public Handler(IDivisionRepository divisionRepository)
            {
                _divisionRepository = divisionRepository;
            }

            protected override async Task<DivisionViewModel> Handle(Query query)
            {
                return new DivisionViewModel(await _divisionRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : IQuery<DivisionViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
