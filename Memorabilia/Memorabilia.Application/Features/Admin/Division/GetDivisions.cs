using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Division
{
    public class GetDivisions
    {
        public class Handler : QueryHandler<Query, DivisionsViewModel>
        {
            private readonly IDivisionRepository _divisionRepository;

            public Handler(IDivisionRepository divisionRepository)
            {
                _divisionRepository = divisionRepository;
            }

            protected override async Task<DivisionsViewModel> Handle(Query query)
            {
                var divisions = await _divisionRepository.GetAll().ConfigureAwait(false);

                var viewModel = new DivisionsViewModel(divisions);

                return viewModel;
            }
        }

        public class Query : IQuery<DivisionsViewModel>
        {
            public Query() { }
        }
    }
}
