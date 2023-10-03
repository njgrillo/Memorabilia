namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

[AuthorizeByRole(Enum.Role.Admin)]
public record GetInternationalHallOfFameTypes() : IQuery<Entity.InternationalHallOfFameType[]>
{
    public class Handler : QueryHandler<GetInternationalHallOfFameTypes, Entity.InternationalHallOfFameType[]>
    {
        private readonly IDomainRepository<Entity.InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<Entity.InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<Entity.InternationalHallOfFameType[]> Handle(GetInternationalHallOfFameTypes query)
            => await _internationalHallOfFameTypeRepository.GetAll();
    }
}
