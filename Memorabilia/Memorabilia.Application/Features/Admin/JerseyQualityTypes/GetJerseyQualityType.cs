namespace Memorabilia.Application.Features.Admin.JerseyQualityTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetJerseyQualityType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetJerseyQualityType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.JerseyQualityType> _jerseyQualityTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyQualityType> jerseyQualityTypeRepository)
        {
            _jerseyQualityTypeRepository = jerseyQualityTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetJerseyQualityType query)
            => await _jerseyQualityTypeRepository.Get(query.Id);
    }
}
