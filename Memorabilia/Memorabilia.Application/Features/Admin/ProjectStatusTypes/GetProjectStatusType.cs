namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusType(int Id) : IQuery<Entity.ProjectStatusType>
{
    public class Handler : QueryHandler<GetProjectStatusType, Entity.ProjectStatusType>
    {
        private readonly IDomainRepository<Entity.ProjectStatusType> _projectStatusTypeRepository;

        public Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository)
        {
            _projectStatusTypeRepository = projectStatusTypeRepository;
        }

        protected override async Task<Entity.ProjectStatusType> Handle(GetProjectStatusType query)
            => await _projectStatusTypeRepository.Get(query.Id);
    }
}
