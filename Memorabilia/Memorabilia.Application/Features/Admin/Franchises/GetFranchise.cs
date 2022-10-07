using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Franchises;

public class GetFranchise
{
    public class Handler : QueryHandler<Query, FranchiseViewModel>
    {
        private readonly IDomainRepository<Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task<FranchiseViewModel> Handle(Query query)
        {
            return new FranchiseViewModel(await _franchiseRepository.Get(query.Id));
        }
    }

    public class Query : IQuery<FranchiseViewModel>
    {
        public Query(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
