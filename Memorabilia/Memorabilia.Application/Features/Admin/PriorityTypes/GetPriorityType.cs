using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record GetPriorityType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetPriorityType, DomainViewModel>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetPriorityType query)
        {
            return new DomainViewModel(await _priorityTypeRepository.Get(query.Id));
        }
    }
}
