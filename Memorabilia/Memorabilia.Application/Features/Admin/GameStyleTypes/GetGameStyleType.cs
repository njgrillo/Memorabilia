namespace Memorabilia.Application.Features.Admin.GameStyleTypes;

public record GetGameStyleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.GameStyleType> gameStyleTypeRepository) 
        : QueryHandler<GetGameStyleType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetGameStyleType query)
            => await gameStyleTypeRepository.Get(query.Id);
    }
}
