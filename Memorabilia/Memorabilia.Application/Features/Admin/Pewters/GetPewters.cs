using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Pewters
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
                return new PewtersViewModel(await _pewterRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<PewtersViewModel> { }
    }
}
