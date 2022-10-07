using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.PrivacyTypes;

public class GetPrivacyType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<PrivacyType> _privacyTypeRepository;

        public Handler(IDomainRepository<PrivacyType> privacyTypeRepository)
        {
            _privacyTypeRepository = privacyTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _privacyTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
