namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record GetInternationalHallOfFameType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository) 
        : QueryHandler<GetInternationalHallOfFameType, Entity.DomainEntity>
    {
        protected override async Task<Entity.DomainEntity> Handle(GetInternationalHallOfFameType query)
            => await internationalHallOfFameTypeRepository.Get(query.Id);
    }
}
