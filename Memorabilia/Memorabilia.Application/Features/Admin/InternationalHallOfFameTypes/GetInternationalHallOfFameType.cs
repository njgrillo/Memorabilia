using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes;

public record GetInternationalHallOfFameType(int Id) : IQuery<DomainModel>
{
    public class Handler : QueryHandler<GetInternationalHallOfFameType, DomainModel>
    {
        private readonly IDomainRepository<InternationalHallOfFameType> _internationalHallOfFameTypeRepository;

        public Handler(IDomainRepository<InternationalHallOfFameType> internationalHallOfFameTypeRepository)
        {
            _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
        }

        protected override async Task<DomainModel> Handle(GetInternationalHallOfFameType query)
        {
            return new DomainModel(await _internationalHallOfFameTypeRepository.Get(query.Id));
        }
    }
}
