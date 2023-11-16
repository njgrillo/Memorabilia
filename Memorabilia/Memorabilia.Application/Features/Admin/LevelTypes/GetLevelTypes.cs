namespace Memorabilia.Application.Features.Admin.LevelTypes;

public record GetLevelTypes() : IQuery<Entity.LevelType[]>
{
    public class Handler(IDomainRepository<Entity.LevelType> levelTypeRepository) 
        : QueryHandler<GetLevelTypes, Entity.LevelType[]>
    {
        protected override async Task<Entity.LevelType[]> Handle(GetLevelTypes query)
            => await levelTypeRepository.GetAll();
    }
}
