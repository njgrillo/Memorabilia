using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public record GetHelmetQualityTypes() : IQuery<HelmetQualityTypesViewModel>
{
    public class Handler : QueryHandler<GetHelmetQualityTypes, HelmetQualityTypesViewModel>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<HelmetQualityTypesViewModel> Handle(GetHelmetQualityTypes query)
        {
            return new HelmetQualityTypesViewModel(await _helmetQualityTypeRepository.GetAll());
        }
    }
}
