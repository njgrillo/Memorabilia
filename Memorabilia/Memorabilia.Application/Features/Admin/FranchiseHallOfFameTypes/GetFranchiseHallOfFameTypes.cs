using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public class GetFranchiseHallOfFameTypes
{
    public class Handler : QueryHandler<Query, FranchiseHallOfFameTypesViewModel>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<FranchiseHallOfFameTypesViewModel> Handle(Query query)
        {
            return new FranchiseHallOfFameTypesViewModel(await _franchiseHallOfFameTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<FranchiseHallOfFameTypesViewModel> { }
}
