namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetAcquisitionTypes() : IQuery<Entity.AcquisitionType[]>
{
    public class Handler : QueryHandler<GetAcquisitionTypes, Entity.AcquisitionType[]>
    {
        private readonly IDomainRepository<Entity.AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<Entity.AcquisitionType[]> Handle(GetAcquisitionTypes query)
            => await _acquisitionTypeRepository.GetAll();
    }
}
