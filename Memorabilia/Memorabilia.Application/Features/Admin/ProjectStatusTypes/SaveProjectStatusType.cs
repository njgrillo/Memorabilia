namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveProjectStatusType(DomainEditModel ProjectStatusType) : ICommand
{
    public class Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository) 
        : CommandHandler<SaveProjectStatusType>
    {
        protected override async Task Handle(SaveProjectStatusType request)
        {
            Entity.ProjectStatusType projectStatusType;

            if (request.ProjectStatusType.IsNew)
            {
                projectStatusType = new Entity.ProjectStatusType(request.ProjectStatusType.Name, 
                                                                 request.ProjectStatusType.Abbreviation);

                await projectStatusTypeRepository.Add(projectStatusType);

                return;
            }

            projectStatusType = await projectStatusTypeRepository.Get(request.ProjectStatusType.Id);

            if (request.ProjectStatusType.IsDeleted)
            {
                await projectStatusTypeRepository.Delete(projectStatusType);

                return;
            }

            projectStatusType.Set(request.ProjectStatusType.Name, 
                                  request.ProjectStatusType.Abbreviation);

            await projectStatusTypeRepository.Update(projectStatusType);
        }
    }
}
