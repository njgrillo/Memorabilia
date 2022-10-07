using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public class GetHelmetQualityType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _helmetQualityTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
