namespace Memorabilia.Application.Features.Admin.LeaderTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetLeaderType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetLeaderType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetLeaderType query)
            => await _leaderTypeRepository.Get(query.Id);
    }
}
