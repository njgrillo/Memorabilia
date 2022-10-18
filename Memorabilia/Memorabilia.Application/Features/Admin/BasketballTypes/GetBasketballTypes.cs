using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballTypes() : IQuery<BasketballTypesViewModel>
{
    public class Handler : QueryHandler<GetBasketballTypes, BasketballTypesViewModel>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<BasketballTypesViewModel> Handle(GetBasketballTypes query)
        {
            return new BasketballTypesViewModel(await _basketballTypeRepository.GetAll());
        }
    }
}
