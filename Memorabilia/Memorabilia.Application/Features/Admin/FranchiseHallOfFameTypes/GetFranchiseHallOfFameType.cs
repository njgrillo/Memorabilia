using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.FranchiseHallOfFameTypes;

public record GetFranchiseHallOfFameType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetFranchiseHallOfFameType, DomainViewModel>
    {
        private readonly IDomainRepository<FranchiseHallOfFameType> _franchiseHallOfFameTypeRepository;

        public Handler(IDomainRepository<FranchiseHallOfFameType> franchiseHallOfFameTypeRepository)
        {
            _franchiseHallOfFameTypeRepository = franchiseHallOfFameTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetFranchiseHallOfFameType query)
        {
            return new DomainViewModel(await _franchiseHallOfFameTypeRepository.Get(query.Id));
        }
    }
}
