using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record SaveProjectStatusType(SaveDomainViewModel ViewModel) : ICommand
{
    public class Handler : CommandHandler<SaveProjectStatusType>
    {
        private readonly IDomainRepository<ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task Handle(SaveProjectStatusType request)
        {
            ProjectStatusType projectStatusType;

            if (request.ViewModel.IsNew)
            {
                projectStatusType = new ProjectStatusType(request.ViewModel.Name, request.ViewModel.Abbreviation);

                await _projectStatusTypeRepository.Add(projectStatusType);

                return;
            }

            projectStatusType = await _projectStatusTypeRepository.Get(request.ViewModel.Id);

            if (request.ViewModel.IsDeleted)
            {
                await _projectStatusTypeRepository.Delete(projectStatusType);

                return;
            }

            projectStatusType.Set(request.ViewModel.Name, request.ViewModel.Abbreviation);

            await _projectStatusTypeRepository.Update(projectStatusType);
        }
    }
}
