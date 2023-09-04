namespace Memorabilia.Application.Features.Admin.LeaderTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record GetLeaderTypes() : IQuery<Entity.LeaderType[]>
{
    public class Handler : QueryHandler<GetLeaderTypes, Entity.LeaderType[]>
    {
        private readonly IDomainRepository<Entity.LeaderType> _leaderTypeRepository;

        public Handler(IDomainRepository<Entity.LeaderType> leaderTypeRepository)
        {
            _leaderTypeRepository = leaderTypeRepository;
        }

        protected override async Task<Entity.LeaderType[]> Handle(GetLeaderTypes query)
            => await _leaderTypeRepository.GetAll();
    }
}
