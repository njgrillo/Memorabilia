namespace Memorabilia.Application.Features.Admin.TeamRoleTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetTeamRoleTypes() : IQuery<Entity.TeamRoleType[]>
{
    public class Handler : QueryHandler<GetTeamRoleTypes, Entity.TeamRoleType[]>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _repository;

        public Handler(IDomainRepository<Entity.TeamRoleType> repository)
        {
            _repository = repository;
        }

        protected override async Task<Entity.TeamRoleType[]> Handle(GetTeamRoleTypes query)
            => await _repository.GetAll();
    }
}
