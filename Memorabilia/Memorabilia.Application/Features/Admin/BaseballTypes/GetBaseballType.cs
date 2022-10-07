using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public class GetBaseballType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<BaseballType> _baseballTypeRepository;

        public Handler(IDomainRepository<BaseballType> baseballTypeRepository)
        {
            _baseballTypeRepository = baseballTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _baseballTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
