using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record GetFranchiseHallOfFameType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFameType, DomainModel>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetFranchiseHallOfFameType query)
        {
            return new DomainModel(await _franchiseHallOfFameTypeRepository.Get(query.Id));
        }
    }
}
