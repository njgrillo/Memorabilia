using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Franchises;

public record GetFranchise(int Id) : IQuery<FranchiseViewModel>
{
    public class Handler : QueryHandler<GetFranchise, FranchiseViewModel>
    {
        private readonly IDomainRepository<Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task<FranchiseViewModel> Handle(GetFranchise query)
        {
            return new FranchiseViewModel(await _franchiseRepository.Get(query.Id));
        }
    }
}
