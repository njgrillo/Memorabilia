namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetFranchiseHallOfFameTypes() : IQuery<Entity.FranchiseHallOfFameType[]>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFameTypes, Entity.FranchiseHallOfFameType[]>
    {
        private readonly IDomainRepository<Entity.FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<Entity.FranchiseHallOfFameType[]> Handle(GetFranchiseHallOfFameTypes query)
            => await _franchiseHallOfFameTypeRepository.GetAll();
    }
}
