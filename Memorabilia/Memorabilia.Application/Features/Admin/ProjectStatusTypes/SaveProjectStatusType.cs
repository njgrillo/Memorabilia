namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record SaveProjectStatusType(DomainEditModel ProjectStatusType) : ICommand
{
    public class Handler : CommandHandler<SaveProjectStatusType>
    {
        private readonly IDomainRepository<Entity.ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task Handle(SaveProjectStatusType request)
        {
            Entity.ProjectStatusType projectStatusType;

            if (request.ProjectStatusType.IsNew)
            {
                projectStatusType = new Entity.ProjectStatusType(request.ProjectStatusType.Name, 
                                                                 request.ProjectStatusType.Abbreviation);

                await _projectStatusTypeRepository.Add(projectStatusType);

                return;
            }

            projectStatusType = await _projectStatusTypeRepository.Get(request.ProjectStatusType.Id);

            if (request.ProjectStatusType.IsDeleted)
            {
                await _projectStatusTypeRepository.Delete(projectStatusType);

                return;
            }

            projectStatusType.Set(request.ProjectStatusType.Name, 
                                  request.ProjectStatusType.Abbreviation);

            await _projectStatusTypeRepository.Update(projectStatusType);
        }
    }
}
