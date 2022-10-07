using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BasketballTypes;

public class GetBasketballType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<BasketballType> _basketballTypeRepository;

        public Handler(IDomainRepository<BasketballType> basketballTypeRepository)
        {
            _basketballTypeRepository = basketballTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _basketballTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
