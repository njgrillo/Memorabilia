using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Conditions;

public record GetCondition(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetCondition, DomainModel>
    {
        private readonly IDomainRepository<Condition> _conditionRepository;

        public Handler(IDomainRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        protected override async Task<DomainModel> Handle(GetCondition query)
        {
            return new DomainModel(await _conditionRepository.Get(query.Id));
        }
    }
}
