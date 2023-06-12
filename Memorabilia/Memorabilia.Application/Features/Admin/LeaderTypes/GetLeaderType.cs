namespace Memorabilia.Application.Features.Admin.LeaderTypes;

public record GetLeaderType(int Id) : IQuery<Entity.LeaderType>
{
    public class Handler : QueryHandler<GetLeaderType, Entity.LeaderType>
    {
        private readonly IDomainRepository<Entity.LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<Entity.LeaderType> Handle(GetLeaderType query)
            => await _leaderTypeRepository.Get(query.Id);
    }
}
