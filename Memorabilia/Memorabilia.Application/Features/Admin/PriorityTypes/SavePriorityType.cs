namespace Memorabilia.Application.Features.Admin.PriorityTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SavePriorityType(DomainEditModel PriorityType) : ICommand
{
    public class Handler(IDomainRepository<Entity.PriorityType> priorityTypeRepository) 
        : CommandHandler<SavePriorityType>
    {
        protected override async Task Handle(SavePriorityType request)
        {
            Entity.PriorityType priorityType;

            if (request.PriorityType.IsNew)
            {
                priorityType = new Entity.PriorityType(request.PriorityType.Name, 
                                                       request.PriorityType.Abbreviation);

                await priorityTypeRepository.Add(priorityType);

                return;
            }

            priorityType = await priorityTypeRepository.Get(request.PriorityType.Id);

            if (request.PriorityType.IsDeleted)
            {
                await priorityTypeRepository.Delete(priorityType);

                return;
            }

            priorityType.Set(request.PriorityType.Name, 
                             request.PriorityType.Abbreviation);

            await priorityTypeRepository.Update(priorityType);
        }
    }
}
