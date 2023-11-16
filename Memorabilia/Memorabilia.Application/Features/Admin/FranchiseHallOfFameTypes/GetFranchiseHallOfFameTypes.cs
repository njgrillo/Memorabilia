namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record GetFranchiseHallOfFameTypes() : IQuery<Entity.FranchiseHallOfFameType[]>
{
    public class Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository) 
        : QueryHandler<GetFranchiseHallOfFameTypes, Entity.FranchiseHallOfFameType[]>
    {
        protected override async Task<Entity.FranchiseHallOfFameType[]> Handle(GetFranchiseHallOfFameTypes query)
            => await franchiseHallOfFameTypeRepository.GetAll();
    }
}
