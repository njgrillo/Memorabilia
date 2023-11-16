namespace Memorabilia.Application.Features.Admin.JerseyTypes;

public record GetJerseyType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.JerseyType> jerseyTypeRepository) 
        : QueryHandler<GetJerseyType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetJerseyType query)
            => await jerseyTypeRepository.Get(query.Id);
    }
}
