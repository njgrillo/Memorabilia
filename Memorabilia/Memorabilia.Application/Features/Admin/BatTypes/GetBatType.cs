using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BatTypes
{
    public class GetBatType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBatTypeRepository _batTypeRepository;

            public Handler(IBatTypeRepository batTypeRepository)
            {
                _batTypeRepository = batTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _batTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
