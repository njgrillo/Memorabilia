using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record GetHelmetQualityType(int Id) : IQuery<DomainViewModel>
{
    public class Handler : QueryHandler<GetHelmetQualityType, DomainViewModel>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<DomainViewModel> Handle(GetHelmetQualityType query)
        {
            return new DomainViewModel(await _helmetQualityTypeRepository.Get(query.Id));
        }
    }
}
