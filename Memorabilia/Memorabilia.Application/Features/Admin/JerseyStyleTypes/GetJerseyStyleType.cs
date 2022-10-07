using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public class GetJerseyStyleType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<JerseyStyleType> _jerseyStyleTypeRepository;

        public Handler(IDomainRepository<JerseyStyleType> jerseyStyleTypeRepository)
        {
            _jerseyStyleTypeRepository = jerseyStyleTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _jerseyStyleTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
