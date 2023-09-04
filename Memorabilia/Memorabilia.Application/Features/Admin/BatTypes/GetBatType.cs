namespace Memorabilia.Application.Features.Admin.BatTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetBatType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetBatType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.BatType> _batTypeRepository;

        public Handler(IDomainRepository<Entity.BatType> batTypeRepository)
        {
            _batTypeRepository = batTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetBatType query)
            => await _batTypeRepository.Get(query.Id);
    }
}
