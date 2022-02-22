using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Division
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
                var division = await _divisionRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DivisionViewModel(division);

                return viewModel;
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
