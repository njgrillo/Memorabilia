using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record GetInternationalHallOfFameType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetInternationalHallOfFameType, DomainViewModel>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetInternationalHallOfFameType query)
        {
            return new DomainViewModel(await _internationalHallOfFameTypeRepository.Get(query.Id));
        }
    }
}
