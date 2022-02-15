using Demo.Framework.Handler;
using Memorabilia.Domain;
using System.Threading.Tasks;

namespace Memorabilia.Application.Features.Admin.BasketballType
{
    public class GetBasketballTypes
    {
        public class Handler : QueryHandler<Query, BasketballTypesViewModel>
        {
            private readonly IBasketballTypeRepository _basketballTypeRepository;

            public Handler(IBasketballTypeRepository basketballTypeRepository)
            {
                _basketballTypeRepository = basketballTypeRepository;
            }

            protected override async Task<BasketballTypesViewModel> Handle(Query query)
            {
                var basketballTypes = await _basketballTypeRepository.GetAll().ConfigureAwait(false);

                var viewModel = new BasketballTypesViewModel(basketballTypes);

                return viewModel;
            }
        }

        public class Query : IQuery<BasketballTypesViewModel> { }
    }
}
