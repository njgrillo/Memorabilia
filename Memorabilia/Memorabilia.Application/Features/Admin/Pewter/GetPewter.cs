using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Pewter
{
    public class GetPewter
    {
        public class Handler : QueryHandler<Query, PewterViewModel>
        {
            private readonly IPewterRepository _pewterRepository;

            public Handler(IPewterRepository pewterRepository)
            {
                _pewterRepository = pewterRepository;
            }

            protected override async Task<PewterViewModel> Handle(Query query)
            {
                var pewter = await _pewterRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new PewterViewModel(pewter);

                return viewModel;
            }
        }

        public class Query : IQuery<PewterViewModel>
        {
            public Query(int id)
            {
                Id = id;
            }

            public int Id { get; }
        }
    }
}
