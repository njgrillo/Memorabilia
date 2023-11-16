namespace Memorabilia.Application.Features.Admin.ProjectTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveProjectType(DomainEditModel ProjectType) : ICommand
{
    public class Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository) 
        : CommandHandler<SaveProjectType>
    {
        protected override async Task Handle(SaveProjectType request)
        {
            Entity.ProjectType projectType;

            if (request.ProjectType.IsNew)
            {
                projectType = new Entity.ProjectType(request.ProjectType.Name, 
                                                     request.ProjectType.Abbreviation);

                await projectTypeRepository.Add(projectType);

                return;
            }

            projectType = await projectTypeRepository.Get(request.ProjectType.Id);

            if (request.ProjectType.IsDeleted)
            {
                await projectTypeRepository.Delete(projectType);

                return;
            }

            projectType.Set(request.ProjectType.Name, 
                            request.ProjectType.Abbreviation);

            await projectTypeRepository.Update(projectType);
        }
    }
}
