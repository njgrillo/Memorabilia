namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

public record GetThroughTheMailFailureType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetThroughTheMailFailureType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.TeamRoleType> _repository;

        public Handler(IDomainRepository<Entity.TeamRoleType> repository)
        {
            _repository = repository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetThroughTheMailFailureType query)
            => await _repository.Get(query.Id);
    }
}
