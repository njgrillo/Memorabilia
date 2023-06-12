namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record GetInternationalHallOfFameType(int Id) : IQuery<Entity.InternationalHallOfFameType>
{
    public class Handler : QueryHandler<GetInternationalHallOfFameType, Entity.InternationalHallOfFameType>
    {
        private readonly IDomainRepository<Entity.InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<Entity.InternationalHallOfFameType> Handle(GetInternationalHallOfFameType query)
            => await _internationalHallOfFameTypeRepository.Get(query.Id);
    }
}
