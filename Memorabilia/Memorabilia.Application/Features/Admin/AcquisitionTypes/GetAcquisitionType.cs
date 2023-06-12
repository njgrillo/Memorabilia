namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

public record GetAcquisitionType(int Id) : IQuery<Entity.AcquisitionType>
{
    public class Handler : QueryHandler<GetAcquisitionType, Entity.AcquisitionType>
    {
        private readonly IDomainRepository<Entity.AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<Entity.AcquisitionType> Handle(GetAcquisitionType query)
            => await _acquisitionTypeRepository.Get(query.Id);
    }
}
