using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public record GetConditions() : IQuery<ConditionsViewModel>
{
    public class Handler : QueryHandler<GetConditions, ConditionsViewModel>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<ConditionsViewModel> Handle(GetConditions query)
        {
            return new ConditionsViewModel(await _conditionRepository.GetAll());
        }
    }
}
