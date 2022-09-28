namespace Memorabilia.Application.Features.Admin.AcquisitionTypes
{
    public class GetAcquisitionTypes
    {
        public class Handler : QueryHandler<Query, AcquisitionTypesViewModel>
        {
            private readonly IAcquisitionTypeRepository _acquisitionTypeRepository;

            public Handler(IAcquisitionTypeRepository acquisitionTypeRepository)
            {
                _acquisitionTypeRepository = acquisitionTypeRepository;
            }

            protected override async Task<AcquisitionTypesViewModel> Handle(Query query)
            {
                return new AcquisitionTypesViewModel(await _acquisitionTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<AcquisitionTypesViewModel> { }
    }
}
