namespace Memorabilia.Application.Features.Admin.AwardTypes;

public record GetAwardType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.AwardType> awardTypeRepository) 
        : QueryHandler<GetAwardType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetAwardType query)
            => await awardTypeRepository.Get(query.Id);
    }
}
