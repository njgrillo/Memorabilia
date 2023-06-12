namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record GetFranchiseHallOfFameType(int Id) : IQuery<Entity.FranchiseHallOfFameType>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFameType, Entity.FranchiseHallOfFameType>
    {
        private readonly IDomainRepository<Entity.FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<Entity.FranchiseHallOfFameType> Handle(GetFranchiseHallOfFameType query)
            => await _franchiseHallOfFameTypeRepository.Get(query.Id);
    }
}
