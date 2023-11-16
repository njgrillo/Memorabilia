namespace Memorabilia.Application.Features.Admin.ProjectStatusTypes;

public record GetProjectStatusTypes() : IQuery<Entity.ProjectStatusType[]>
{
    public class Handler(IDomainRepository<Entity.ProjectStatusType> projectStatusTypeRepository) 
        : QueryHandler<GetProjectStatusTypes, Entity.ProjectStatusType[]>
    {
        protected override async Task<Entity.ProjectStatusType[]> Handle(GetProjectStatusTypes query)
            => await projectStatusTypeRepository.GetAll();
    }
}
