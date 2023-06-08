namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionTypes() : IQuery<AcquisitionTypesModel>
{
    public class Handler : QueryHandler<GetAcquisitionTypes, AcquisitionTypesModel>
    {
        private readonly IDomainRepository<Entity.AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<AcquisitionTypesModel> Handle(GetAcquisitionTypes query)
        {
            return new AcquisitionTypesModel(await _acquisitionTypeRepository.GetAll());
        }
    }
}
