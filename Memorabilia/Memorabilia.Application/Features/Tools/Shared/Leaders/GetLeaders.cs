﻿namespace Memorabilia.Application.Features.Tools.Shared.Leaders;

public record GetLeaders(Constant.LeaderType LeaderType, 
                         Constant.Sport Sport) 
    : IQuery<Entity.Leader[]>
{
    public class Handler : QueryHandler<GetLeaders, Entity.Leader[]>
    {
        private readonly ILeaderRepository _leaderRepository;

        public Handler(ILeaderRepository leaderRepository)
        {
            _leaderRepository = leaderRepository;
        }

        protected override async Task<Entity.Leader[]> Handle(GetLeaders query)
            => (await _leaderRepository.GetAll(query.LeaderType.Id))
                    .ToArray();
    }
}
