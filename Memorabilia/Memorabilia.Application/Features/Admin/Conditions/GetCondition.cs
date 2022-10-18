using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public record GetCondition(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetCondition, DomainViewModel>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetCondition query)
        {
            return new DomainViewModel(await _conditionRepository.Get(query.Id));
        }
    }
}
