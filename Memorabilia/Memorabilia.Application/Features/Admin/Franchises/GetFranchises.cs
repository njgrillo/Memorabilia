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
           return new FranchisesViewModel(await _franchiseRepository.GetAll());
        }
    }
}
