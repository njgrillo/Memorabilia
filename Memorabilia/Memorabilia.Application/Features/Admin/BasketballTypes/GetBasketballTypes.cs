using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public class GetBasketballTypes
{
    public class Handler : QueryHandler<Query, BasketballTypesViewModel>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<BasketballTypesViewModel> Handle(Query query)
        {
            return new BasketballTypesViewModel(await _basketballTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<BasketballTypesViewModel> { }
}
