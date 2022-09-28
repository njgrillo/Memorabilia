namespace Memorabilia.Application.Features.Admin.BasketballTypes
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
                return new BasketballTypesViewModel(await _basketballTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<BasketballTypesViewModel> { }
    }
}
