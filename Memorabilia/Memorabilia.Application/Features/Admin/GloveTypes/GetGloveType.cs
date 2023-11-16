namespace Memorabilia.Application.Features.Admin.GloveTypes;

public record GetGloveType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.GloveType> gloveTypeRepository) 
        : QueryHandler<GetGloveType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetGloveType query)
            => await gloveTypeRepository.Get(query.Id);
    }
}
