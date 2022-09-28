namespace Memorabilia.Application.Features.Admin.LeaderTypes
{
    public class GetLeaderTypes
    {
        public class Handler : QueryHandler<Query, LeaderTypesViewModel>
        {
            private readonly ILeaderTypeRepository _leaderTypeRepository;

            public Handler(ILeaderTypeRepository leaderTypeRepository)
            {
                _leaderTypeRepository = leaderTypeRepository;
            }

            protected override async Task<LeaderTypesViewModel> Handle(Query query)
            {
                return new LeaderTypesViewModel(await _leaderTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<LeaderTypesViewModel> { }
    }
}
