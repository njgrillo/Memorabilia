namespace Memorabilia.Application.Features.Admin.BammerTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetBammerType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetBammerType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.BammerType> _bammerTypeRepository;

        public Handler(IDomainRepository<Entity.BammerType> bammerTypeRepository)
        {
            _bammerTypeRepository = bammerTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetBammerType query)
            => await _bammerTypeRepository.Get(query.Id);
    }
}
