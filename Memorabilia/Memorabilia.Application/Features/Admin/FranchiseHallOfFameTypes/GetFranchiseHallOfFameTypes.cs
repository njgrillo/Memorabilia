using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record GetFranchiseHallOfFameTypes() : IQuery<FranchiseHallOfFameTypesViewModel>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFameTypes, FranchiseHallOfFameTypesViewModel>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<FranchiseHallOfFameTypesViewModel> Handle(GetFranchiseHallOfFameTypes query)
        {
            return new FranchiseHallOfFameTypesViewModel(await _franchiseHallOfFameTypeRepository.GetAll());
        }
    }
}
