namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetTeamRoleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetTeamRoleType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _repository;

        public Handler(IDomainRepository<Entity.TeamRoleType> repository)
        {
            _repository = repository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetTeamRoleType query)
            => await _repository.Get(query.Id);
    }
}
