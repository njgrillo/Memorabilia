using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public class GetConditions
{
    public class Handler : QueryHandler<Query, ConditionsViewModel>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<ConditionsViewModel> Handle(Query query)
        {
            return new ConditionsViewModel(await _conditionRepository.GetAll());
        }
    }

    public class Query : IQuery<ConditionsViewModel> { }
}
