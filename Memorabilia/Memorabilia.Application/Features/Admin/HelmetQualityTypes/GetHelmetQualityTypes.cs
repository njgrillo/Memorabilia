namespace Memorabilia.Application.Features.Admin.HelmetQualityTypes
{
    public class GetHelmetQualityTypes
    {
        public class Handler : QueryHandler<Query, HelmetQualityTypesViewModel>
        {
            private readonly IHelmetQualityTypeRepository _helmetQualityTypeRepository;

            public Handler(IHelmetQualityTypeRepository helmetQualityTypeRepository)
            {
                _helmetQualityTypeRepository = helmetQualityTypeRepository;
            }

            protected override async Task<HelmetQualityTypesViewModel> Handle(Query query)
            {
                return new HelmetQualityTypesViewModel(await _helmetQualityTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<HelmetQualityTypesViewModel> { }
    }
}
