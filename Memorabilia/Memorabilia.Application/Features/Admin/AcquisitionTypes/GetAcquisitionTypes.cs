using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionTypes() : IQuery<AcquisitionTypesViewModel>
{
    public class Handler : QueryHandler<GetAcquisitionTypes, AcquisitionTypesViewModel>
    {
        private readonly IDomainRepository<AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<AcquisitionTypesViewModel> Handle(GetAcquisitionTypes query)
        {
            return new AcquisitionTypesViewModel(await _acquisitionTypeRepository.GetAll());
        }
    }
}
