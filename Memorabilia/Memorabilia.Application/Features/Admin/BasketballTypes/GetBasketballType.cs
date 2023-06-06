using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public record GetBasketballType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetBasketballType, DomainModel>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetBasketballType query)
        {
            return new DomainModel(await _basketballTypeRepository.Get(query.Id));
        }
    }
}
