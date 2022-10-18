using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public record GetPriorityTypes() : IQuery<PriorityTypesViewModel>
{
    public class Handler : QueryHandler<GetPriorityTypes, PriorityTypesViewModel>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<PriorityTypesViewModel> Handle(GetPriorityTypes query)
        {
            return new PriorityTypesViewModel(await _priorityTypeRepository.GetAll());
        }
    }
}
