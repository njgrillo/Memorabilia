namespace Memorabilia.Application.Features.Admin.LevelTypes;

public record GetLevelType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.LevelType> levelTypeRepository) 
        : QueryHandler<GetLevelType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetLevelType query)
            => await levelTypeRepository.Get(query.Id);
    }
}
