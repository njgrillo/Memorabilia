namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public record GetLeaders(Constant.LeaderType LeaderType, 
                         Constant.Sport Sport) 
    : IQuery<Entity.Leader[]>
{
    public class Handler(ILeaderRepository leaderRepository) 
        : QueryHandler<GetLeaders, Entity.Leader[]>
    {
        protected override async Task<Entity.Leader[]> Handle(GetLeaders query)
            => (await leaderRepository.GetAll(query.LeaderType.Id))
                    .ToArray();
    }
}
