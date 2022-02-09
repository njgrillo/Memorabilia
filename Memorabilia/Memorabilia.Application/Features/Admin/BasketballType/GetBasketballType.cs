using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BasketballType
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
                var basketballType = await _basketballTypeRepository.Get(query.Id).ConfigureAwait(false);

                var viewModel = new DomainViewModel(basketballType);

                return viewModel;
            }
        }

        public class Query : DomainQuery
        {
            public Query(int id) : base(id)
            {
            }
        }
    }
}
