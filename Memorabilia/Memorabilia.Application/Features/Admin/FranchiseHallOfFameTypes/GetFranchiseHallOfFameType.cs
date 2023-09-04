namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetFranchiseHallOfFameType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFameType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetFranchiseHallOfFameType query)
            => await _franchiseHallOfFameTypeRepository.Get(query.Id);
    }
}
