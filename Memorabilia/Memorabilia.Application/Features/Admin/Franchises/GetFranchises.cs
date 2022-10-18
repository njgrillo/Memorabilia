using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.Franchises;

public record GetFranchises() : IQuery<FranchisesViewModel>
{
    public class Handler : QueryHandler<GetFranchises, FranchisesViewModel>
    {
        private readonly IDomainRepository<Franchise> _franchiseRepository;

        public Handler(IDomainRepository<Franchise> franchiseRepository)
        {
            _franchiseRepository = franchiseRepository;
        }

        protected override async Task<FranchisesViewModel> Handle(GetFranchises query)
        {
            var franchises = (await _franchiseRepository.GetAll())
                                    .OrderBy(franchise => franchise.SportLeagueLevelName)
                                    .ThenBy(franchise => franchise.Name);

            return new FranchisesViewModel(franchises);
        }
    }
}
