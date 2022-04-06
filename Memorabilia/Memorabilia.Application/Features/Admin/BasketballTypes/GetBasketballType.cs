using Demo.Framework.Handler;
using Memorabilia.Repository.Interfaces;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BasketballTypes
{
    public class GetBasketballType
    {
        public class Handler : QueryHandler<Query, DomainViewModel>
        {
            private readonly IBasketballTypeRepository _basketballTypeRepository;

            public Handler(IBasketballTypeRepository basketballTypeRepository)
            {
                _basketballTypeRepository = basketballTypeRepository;
            }

            protected override async Task<DomainViewModel> Handle(Query query)
            {
                return new DomainViewModel(await _basketballTypeRepository.Get(query.Id).ConfigureAwait(false));
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id) { }
        }
    }
}
