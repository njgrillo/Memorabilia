namespace Memorabilia.Application.Features.Admin.HelmetTypes;

public record GetHelmetType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.HelmetType> helmetTypeRepository) 
        : QueryHandler<GetHelmetType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetHelmetType query)
            => await helmetTypeRepository.Get(query.Id);
    }
}
