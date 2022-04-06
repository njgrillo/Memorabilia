using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.Occupations
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
                return new DomainViewModel(await _occupationRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
