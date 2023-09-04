namespace Memorabilia.Application.Features.Admin.PriorityTypes;

[AuthorizeByRole(Enum.PermissionType.Admin)]
public record SavePriorityType(DomainEditModel PriorityType) : ICommand
{
    public class Handler : CommandHandler<SavePriorityType>
    {
        private readonly IDomainRepository<Entity.PriorityType> _priorityTypeRepository;

        public Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository)
        {
            _priorityTypeRepository = priorityTypeRepository;
        }

        protected override async Task Handle(SavePriorityType request)
        {
            Entity.PriorityType priorityType;

            if (request.PriorityType.IsNew)
            {
                priorityType = new Entity.PriorityType(request.PriorityType.Name, 
                                                       request.PriorityType.Abbreviation);

                await _priorityTypeRepository.Add(priorityType);

                return;
            }

            priorityType = await _priorityTypeRepository.Get(request.PriorityType.Id);

            if (request.PriorityType.IsDeleted)
            {
                await _priorityTypeRepository.Delete(priorityType);

                return;
            }

            priorityType.Set(request.PriorityType.Name, 
                             request.PriorityType.Abbreviation);

            await _priorityTypeRepository.Update(priorityType);
        }
    }
}
