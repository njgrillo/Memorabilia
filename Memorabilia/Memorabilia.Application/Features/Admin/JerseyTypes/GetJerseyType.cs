namespace Memorabilia.Application.Features.Admin.JerseyTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetJerseyType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetJerseyType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.JerseyType> _jerseyTypeRepository;

        public Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository)
        {
            _jerseyTypeRepository = jerseyTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetJerseyType query)
            => await _jerseyTypeRepository.Get(query.Id);
    }
}
