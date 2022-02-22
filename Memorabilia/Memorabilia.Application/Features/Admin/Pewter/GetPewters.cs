using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Pewter
{
    public class GetPewters
    {
        public class Handler : QueryHandler<Query, PewtersViewModel>
        {
            private readonly IPewterRepository _pewterRepository;

            public Handler(IPewterRepository pewterRepository)
            {
                _pewterRepository = pewterRepository;
            }

            protected override async Task<PewtersViewModel> Handle(Query query)
            {
                var pewters = await _pewterRepository.GetAll().ConfigureAwait(false);

                var viewModel = new PewtersViewModel(pewters);

                return viewModel;
            }
        }

        public class Query : IQuery<PewtersViewModel> { }
    }
}
