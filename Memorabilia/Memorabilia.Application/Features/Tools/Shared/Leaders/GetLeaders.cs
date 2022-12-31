using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public record GetLeaders(LeaderType LeaderType, Sport Sport) : IQuery<LeadersViewModel>
{
    public class Handler : QueryHandler<GetLeaders, LeadersViewModel>
    {
        private readonly ILeaderRepository _leaderRepository;

        public Handler(ILeaderRepository leaderRepository)
        {
            _leaderRepository = leaderRepository;
        }

        protected override async Task<LeadersViewModel> Handle(GetLeaders query)
        {
            return new LeadersViewModel(await _leaderRepository.GetAll(query.LeaderType.Id), query.Sport)
            {
                LeaderType = query.LeaderType
            };
        }
    }
}
