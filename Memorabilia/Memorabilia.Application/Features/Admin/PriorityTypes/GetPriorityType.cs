using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record GetPriorityType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetPriorityType, DomainModel>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetPriorityType query)
        {
            return new DomainModel(await _priorityTypeRepository.Get(query.Id));
        }
    }
}
