namespace Memorabilia.Application.Features.Admin.ProjectTypes;

public record GetProjectTypes : IQuery<Entity.ProjectType[]>
{
    public class Handler(IDomainRepository<Entity.ProjectType> projectTypeRepository) 
        : QueryHandler<GetProjectTypes, Entity.ProjectType[]>
    {
        protected override async Task<Entity.ProjectType[]> Handle(GetProjectTypes query)
            => await projectTypeRepository.GetAll();
    }
}
