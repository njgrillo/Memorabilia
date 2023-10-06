namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

public record GetThroughTheMailFailureTypes() : IQuery<Entity.ThroughTheMailFailureType[]>
{
    public class Handler : QueryHandler<GetThroughTheMailFailureTypes, Entity.ThroughTheMailFailureType[]>
    {
        private readonly IDomainRepository<Entity.ThroughTheMailFailureType> _repository;

        public Handler(IDomainRepository<Entity.ThroughTheMailFailureType> repository)
        {
            _repository = repository;
        }

        protected override async Task<Entity.ThroughTheMailFailureType[]> Handle(GetThroughTheMailFailureTypes query)
            => await _repository.GetAll();
    }
}
