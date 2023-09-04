namespace Memorabilia.Application.Features.Admin.ThroughTheMailFailureTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SaveThroughTheMailFailureType(DomainEditModel ThroughTheMailFailureType) : ICommand
{
    public class Handler : CommandHandler<SaveThroughTheMailFailureType>
    {
        private readonly IDomainRepository<Entity.ThroughTheMailFailureType> _repository;

        public Handler(IDomainRepository<Entity.ThroughTheMailFailureType> repository)
        {
            _repository = repository;
        }

        protected override async Task Handle(SaveThroughTheMailFailureType request)
        {
            Entity.ThroughTheMailFailureType throughTheMailFailureType;

            if (request.ThroughTheMailFailureType.IsNew)
            {
                throughTheMailFailureType = new Entity.ThroughTheMailFailureType(request.ThroughTheMailFailureType.Name,
                                                                                 request.ThroughTheMailFailureType.Abbreviation);

                await _repository.Add(throughTheMailFailureType);

                return;
            }

            throughTheMailFailureType = await _repository.Get(request.ThroughTheMailFailureType.Id);

            if (request.ThroughTheMailFailureType.IsDeleted)
            {
                await _repository.Delete(throughTheMailFailureType);

                return;
            }

            throughTheMailFailureType.Set(request.ThroughTheMailFailureType.Name,
                                          request.ThroughTheMailFailureType.Abbreviation);

            await _repository.Update(throughTheMailFailureType);
        }
    }
}
