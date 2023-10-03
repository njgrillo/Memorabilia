namespace Memorabilia.Application.Features.Admin.AcquisitionTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetAcquisitionType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetAcquisitionType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.AcquisitionType> _acquisitionTypeRepository;

        public Handler(IDomainRepository<Entity.AcquisitionType> acquisitionTypeRepository)
        {
            _acquisitionTypeRepository = acquisitionTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetAcquisitionType query)
            => await _acquisitionTypeRepository.Get(query.Id);
    }
}
