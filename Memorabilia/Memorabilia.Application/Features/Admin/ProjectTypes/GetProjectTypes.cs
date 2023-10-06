namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectTypes : IQuery<Entity.ProjectType[]>
{
    public class Handler : QueryHandler<GetProjectTypes, Entity.ProjectType[]>
    {
        private readonly IDomainRepository<Entity.ProjectType> _projectTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository)
        {
            _projectTypeRepository = projectTypeRepository;
        }

        protected override async Task<Entity.ProjectType[]> Handle(GetProjectTypes query)
            => await _projectTypeRepository.GetAll();
    }
}
