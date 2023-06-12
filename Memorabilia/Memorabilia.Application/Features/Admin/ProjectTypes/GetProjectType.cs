namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectType(int Id) : IQuery<Entity.ProjectType>
{
    public class Handler : QueryHandler<GetProjectType, Entity.ProjectType>
    {
        private readonly IDomainRepository<Entity.ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task<Entity.ProjectType> Handle(GetProjectType query)
            => await _projectTypeRepository.Get(query.Id);
    }
}
