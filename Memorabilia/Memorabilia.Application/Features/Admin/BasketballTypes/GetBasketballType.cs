using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetBasketballType, DomainViewModel>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetBasketballType query)
        {
            return new DomainViewModel(await _basketballTypeRepository.Get(query.Id));
        }
    }
}
