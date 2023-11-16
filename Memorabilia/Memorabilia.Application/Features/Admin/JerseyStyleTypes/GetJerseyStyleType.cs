namespace Memorabilia.Application.Features.Admin.JerseyStyleTypes;

public record GetJerseyStyleType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.JerseyStyleType> jerseyStyleTypeRepository) 
        : QueryHandler<GetJerseyStyleType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetJerseyStyleType query)
            => await jerseyStyleTypeRepository.Get(query.Id);
    }
}
