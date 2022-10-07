using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PriorityTypes;

public class GetPriorityType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _priorityTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
