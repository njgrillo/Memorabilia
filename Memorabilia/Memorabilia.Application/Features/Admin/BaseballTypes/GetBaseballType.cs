using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BaseballTypes
{
    public class GetBaseballType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBaseballTypeRepository _baseballTypeRepository;

            public Handler(IBaseballTypeRepository baseballTypeRepository)
            {
                _baseballTypeRepository = baseballTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _baseballTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
