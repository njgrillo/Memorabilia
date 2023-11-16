namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record GetFranchiseHallOfFameType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository) 
        : QueryHandler<GetFranchiseHallOfFameType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetFranchiseHallOfFameType query)
            => await franchiseHallOfFameTypeRepository.Get(query.Id);
    }
}
