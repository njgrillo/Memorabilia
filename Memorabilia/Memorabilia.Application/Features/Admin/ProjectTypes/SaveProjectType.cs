using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record SaveProjectType(DomainEditModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveProjectType>
{
    private readonly IDomainRepository<ProjectType> _projectTypeRepository;

    public Handler(IDomainRepository<ProjectType> projectTypeRepository)
    {
        _projectTypeRepository = projectTypeRepository;
    }

    protected override async Task Handle(SaveProjectType request)
    {
        ProjectType projectType;

        if (request.ViewModel.IsNew)
        {
            projectType = new ProjectType(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _projectTypeRepository.Add(projectType);

            return;
        }

        projectType = await _projectTypeRepository.Get(request.ViewModel.Id);

        if (request.ViewModel.IsDeleted)
        {
            await _projectTypeRepository.Delete(projectType);

            return;
        }

        projectType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

        await _projectTypeRepository.Update(projectType);
    }
}
}
