namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveThroughTheMailFailureType(DomainEditModel ThroughTheMailFailureType) : ICommand
{
    public class Handler(IDomainRepository<Entity.ThroughTheMailFailureType> repository) 
        : CommandHandler<SaveThroughTheMailFailureType>
    {
        protected override async Task Handle(SaveThroughTheMailFailureType request)
        {
            Entity.ThroughTheMailFailureType throughTheMailFailureType;

            if (request.ThroughTheMailFailureType.IsNew)
            {
                throughTheMailFailureType = new Entity.ThroughTheMailFailureType(request.ThroughTheMailFailureType.Name,
                                                                                 request.ThroughTheMailFailureType.Abbreviation);

                await repository.Add(throughTheMailFailureType);

                return;
            }

            throughTheMailFailureType = await repository.Get(request.ThroughTheMailFailureType.Id);

            if (request.ThroughTheMailFailureType.IsDeleted)
            {
                await repository.Delete(throughTheMailFailureType);

                return;
            }

            throughTheMailFailureType.Set(request.ThroughTheMailFailureType.Name,
                                          request.ThroughTheMailFailureType.Abbreviation);

            await repository.Update(throughTheMailFailureType);
        }
    }
}
