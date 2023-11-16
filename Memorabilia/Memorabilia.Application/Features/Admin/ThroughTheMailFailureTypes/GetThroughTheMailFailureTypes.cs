namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

public record GetThroughTheMailFailureTypes() : IQuery<Entity.ThroughTheMailFailureType[]>
{
    public class Handler(IDomainRepository<Entity.ThroughTheMailFailureType> repository) 
        : QueryHandler<GetThroughTheMailFailureTypes, Entity.ThroughTheMailFailureType[]>
    {
        protected override async Task<Entity.ThroughTheMailFailureType[]> Handle(GetThroughTheMailFailureTypes query)
            => await repository.GetAll();
    }
}
