using Memorabilia.Domain.Entities;

namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes;

public class GetHelmetQualityTypes
{
    public class Handler : QueryHandler<Query, HelmetQualityTypesViewModel>
    {
        private readonly IDomainRepository<HelmetQualityType> _helmetQualityTypeRepository;

        public Handler(IDomainRepository<HelmetQualityType> helmetQualityTypeRepository)
        {
            _helmetQualityTypeRepository = helmetQualityTypeRepository;
        }

        protected override async Task<HelmetQualityTypesViewModel> Handle(Query query)
        {
            return new HelmetQualityTypesViewModel(await _helmetQualityTypeRepository.GetAll());
        }
    }

    public class Query : IQuery<HelmetQualityTypesViewModel> { }
}
