using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Occupation
{
    public class GetOccupation
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IOccupationRepository _occupationRepository;

            public Handler(IOccupationRepository occupationRepository)
            {
                _occupationRepository = occupationRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                var occupation = await _occupationRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(occupation);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
