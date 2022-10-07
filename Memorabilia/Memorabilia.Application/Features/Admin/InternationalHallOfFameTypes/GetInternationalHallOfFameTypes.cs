using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public class GetInternationalHallOfFameTypes
{
    public class Handler : QueryHandler<Query, InternationalHallOfFameTypesViewModel>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<InternationalHallOfFameTypesViewModel> Handle(Query query)
        {
            return new InternationalHallOfFameTypesViewModel(await _internationalHallOfFameTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<InternationalHallOfFameTypesViewModel> { }
}
