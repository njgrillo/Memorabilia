namespace Memorabilia.Application.Features.Admin.ProjectTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record SaveProjectType(DomainEditModel ProjectType) : ICommand
{
    public class Handler : CommandHandler<SaveProjectType>
    {
        private readonly IDomainRepository<Entity.ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task Handle(SaveProjectType request)
        {
            Entity.ProjectType projectType;

            if (request.ProjectType.IsNew)
            {
                projectType = new Entity.ProjectType(request.ProjectType.Name, 
                                                     request.ProjectType.Abbreviation);

                await _projectTypeRepository.Add(projectType);

                return;
            }

            projectType = await _projectTypeRepository.Get(request.ProjectType.Id);

            if (request.ProjectType.IsDeleted)
            {
                await _projectTypeRepository.Delete(projectType);

                return;
            }

            projectType.Set(request.ProjectType.Name, 
                            request.ProjectType.Abbreviation);

            await _projectTypeRepository.Update(projectType);
        }
    }
}
