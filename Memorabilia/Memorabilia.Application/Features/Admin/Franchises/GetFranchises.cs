using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Franchises;

public class GetFranchises
{
    public class Handler : QueryHandler<Query, FranchisesViewModel>
    {
        private readonly IDomainRepository<Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task<FranchisesViewModel> Handle(Query query)
        {
            var franchises = (await _franchiseRepository.GetAll())
                                    .OrderBy(franchise => franchise.SportLeagueLevelName)
                                    .ThenBy(franchise => franchise.Name);

            return new FranchisesViewModel(franchises);
        }
    }

    public class Query : IQuery<FranchisesViewModel> { }
}
