using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record GetLeaderTypes() : IQuery<LeaderTypesViewModel>
{
    public class Handler : QueryHandler<GetLeaderTypes, LeaderTypesViewModel>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<LeaderTypesViewModel> Handle(GetLeaderTypes query)
        {
            return new LeaderTypesViewModel(await _leaderTypeRepository.GetAll());
        }
    }
}
