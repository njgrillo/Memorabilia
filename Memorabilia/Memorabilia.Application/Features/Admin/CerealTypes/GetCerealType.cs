namespace Memorabilia.Application.Features.Admin.CerealTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetCerealType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetCerealType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.CerealType> _CerealTypeRepository;

        public Handler(IDomainRepository<Entity.CerealType> CerealTypeRepository)
        {
            _CerealTypeRepository = CerealTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetCerealType query)
            => await _CerealTypeRepository.Get(query.Id);
    }
}
