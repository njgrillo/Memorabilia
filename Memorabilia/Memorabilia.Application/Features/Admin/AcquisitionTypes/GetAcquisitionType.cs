using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public class GetAcquisitionType
{
    public class Handler : QueryHandler<Query, DomainViewModel>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(Query query)
        {
            return new DomainViewModel(await _acquisitionTypeRepository.Get(query.Id));
        }
    }

    public class Query : DomainQuery
    {
        public Query(int id) : base(id) { }
    }
}
