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
            return new FranchisesViewModel(await _franchiseRepository.GetAll());
        }
    }

    public class Query : IQuery<FranchisesViewModel> { }
}
