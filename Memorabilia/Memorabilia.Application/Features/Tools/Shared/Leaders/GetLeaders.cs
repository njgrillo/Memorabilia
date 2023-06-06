using Memorabilia.Domain.Constants;

namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public record GetLeaders(LeaderType LeaderType, Sport Sport) : IQuery<LeadersModel>
{
    public class Handler : QueryHandler<GetLeaders, LeadersModel>
    {
        private readonly ILeaderRepository _leaderRepository;

        public Handler(ILeaderRepository leaderRepository)
        {
            _leaderRepository = leaderRepository;
        }

        protected override async Task<LeadersModel> Handle(GetLeaders query)
        {
            return new LeadersModel(await _leaderRepository.GetAll(query.LeaderType.Id), query.Sport)
            {
                LeaderType = query.LeaderType
            };
        }
    }
}
