namespace Memorabilia.Application.Features.Admin.BatTypes;

public record GetBatType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.BatType> batTypeRepository) 
        : QueryHandler<GetBatType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetBatType query)
            => await batTypeRepository.Get(query.Id);
    }
}
