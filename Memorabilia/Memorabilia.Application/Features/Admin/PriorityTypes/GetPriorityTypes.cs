using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public class GetPriorityTypes
{
    public class Handler : QueryHandler<Query, PriorityTypesViewModel>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<PriorityTypesViewModel> Handle(Query query)
        {
            return new PriorityTypesViewModel(await _priorityTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<PriorityTypesViewModel> { }
}
