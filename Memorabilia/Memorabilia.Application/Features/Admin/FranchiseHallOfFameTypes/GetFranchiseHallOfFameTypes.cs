namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes
{
    public class GetFranchiseHallOfFameTypes
    {
        public class Handler : QueryHandler<Query, FranchiseHallOfFameTypesViewModel>
        {
            private readonly IFranchiseHallOfFameTypeRepository _franchiseHallOfFameTypeRepository;

            public Handler(IFranchiseHallOfFameTypeRepository franchiseHallOfFameTypeRepository)
            {
                _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
            }

            protected override async Task<FranchiseHallOfFameTypesViewModel> Handle(Query query)
            {
                return new FranchiseHallOfFameTypesViewModel(await _franchiseHallOfFameTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<FranchiseHallOfFameTypesViewModel> { }
    }
}
