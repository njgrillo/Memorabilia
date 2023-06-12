namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusTypes() : IQuery<Entity.ProjectStatusType[]>
{
    public class Handler : QueryHandler<GetProjectStatusTypes, Entity.ProjectStatusType[]>
    {
        private readonly IDomainRepository<Entity.ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task<Entity.ProjectStatusType[]> Handle(GetProjectStatusTypes query)
            => (await _projectStatusTypeRepository.GetAll())
                    .ToArray();
    }
}
