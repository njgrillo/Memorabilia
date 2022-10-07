using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public class GetJerseyType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _jerseyTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
