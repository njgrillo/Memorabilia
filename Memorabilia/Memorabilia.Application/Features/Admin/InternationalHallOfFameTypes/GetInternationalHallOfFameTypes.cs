using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record GetInternationalHallOfFameTypes() : IQuery<InternationalHallOfFameTypesViewModel>
{
    public class Handler : QueryHandler<GetInternationalHallOfFameTypes, InternationalHallOfFameTypesViewModel>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<InternationalHallOfFameTypesViewModel> Handle(GetInternationalHallOfFameTypes query)
        {
            return new InternationalHallOfFameTypesViewModel(await _internationalHallOfFameTypeRepository.GetAll());
        }
    }
}
