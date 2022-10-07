using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public class GetLeaderTypes
{
    public class Handler : QueryHandler<Query, LeaderTypesViewModel>
    {
        private readonly IDomainRepository<LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<LeaderTypesViewModel> Handle(Query query)
        {
            return new LeaderTypesViewModel(await _leaderTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<LeaderTypesViewModel> { }
}
