using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public class GetAcquisitionTypes
{
    public class Handler : QueryHandler<Query, AcquisitionTypesViewModel>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<AcquisitionTypesViewModel> Handle(Query query)
        {
            return new AcquisitionTypesViewModel(await _acquisitionTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<AcquisitionTypesViewModel> { }
}
