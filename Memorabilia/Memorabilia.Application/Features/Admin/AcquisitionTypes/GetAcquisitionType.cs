namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetAcquisitionType, DomainModel>
    {
        private readonly IDomainRepository<Entity.AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetAcquisitionType query)
        {
            return new DomainModel(await _acquisitionTypeRepository.Get(query.Id));
        }
    }
}
