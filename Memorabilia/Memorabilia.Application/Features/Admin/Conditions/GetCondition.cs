using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public class GetCondition
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _conditionRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
