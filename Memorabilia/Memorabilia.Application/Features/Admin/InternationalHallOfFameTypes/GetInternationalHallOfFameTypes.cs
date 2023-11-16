namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record GetInternationalHallOfFameTypes() : IQuery<Entity.InternationalHallOfFameType[]>
{
    public class Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository) 
        : QueryHandler<GetInternationalHallOfFameTypes, Entity.InternationalHallOfFameType[]>
    {
        protected override async Task<Entity.InternationalHallOfFameType[]> Handle(GetInternationalHallOfFameTypes query)
            => await internationalHallOfFameTypeRepository.GetAll();
    }
}
