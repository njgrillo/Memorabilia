using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

public class GetJerseyQualityType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _jerseyQualityTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
