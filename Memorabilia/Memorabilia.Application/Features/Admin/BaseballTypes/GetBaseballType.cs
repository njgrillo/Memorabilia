namespace Memorabilia.Application.Features.Admin.BaseballTypes;

public record GetBaseballType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.BaseballType> baseballTypeRepository) 
        : QueryHandler<GetBaseballType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetBaseballType query)
            => await baseballTypeRepository.Get(query.Id);
    }
}
