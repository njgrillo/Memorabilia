namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetInternationalHallOfFameType(int Id) : IQuery<Entity.DomainEntity>
{
    public class Handler : QueryHandler<GetInternationalHallOfFameType, Entity.DomainEntity>
    {
        private readonly IDomainRepository<Entity.InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<Entity.DomainEntity> Handle(GetInternationalHallOfFameType query)
            => await _internationalHallOfFameTypeRepository.Get(query.Id);
    }
}
