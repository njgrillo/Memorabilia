namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetHelmetQualityType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetHelmetQualityType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<Entity.HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetHelmetQualityType query)
            => await _helmetQualityTypeRepository.Get(query.Id);
    }
}
