namespace Memorabilia.Application.Features.Admin.HelmetTypes
{
    public class GetHelmetTypes
    {
        public class Handler : QueryHandler<Query, HelmetTypesViewModel>
        {
            private readonly IHelmetTypeRepository _helmetTypeRepository;

            public Handler(IHelmetTypeRepository helmetTypeRepository)
            {
                _helmetTypeRepository = helmetTypeRepository;
            }

            protected override async Task<HelmetTypesViewModel> Handle(Query query)
            {
                return new HelmetTypesViewModel(await _helmetTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<HelmetTypesViewModel> { }
    }
}
