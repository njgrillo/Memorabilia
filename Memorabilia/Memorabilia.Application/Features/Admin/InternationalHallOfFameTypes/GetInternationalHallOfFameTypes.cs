namespace Memorabilia.Application.Features.Admin.InternationalHallOfFameTypes
{
    public class GetInternationalHallOfFameTypes
    {
        public class Handler : QueryHandler<Query, InternationalHallOfFameTypesViewModel>
        {
            private readonly IInternationalHallOfFameTypeRepository _internationalHallOfFameTypeRepository;

            public Handler(IInternationalHallOfFameTypeRepository internationalHallOfFameTypeRepository)
            {
                _internationalHallOfFameTypeRepository = internationalHallOfFameTypeRepository;
            }

            protected override async Task<InternationalHallOfFameTypesViewModel> Handle(Query query)
            {
                return new InternationalHallOfFameTypesViewModel(await _internationalHallOfFameTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<InternationalHallOfFameTypesViewModel> { }
    }
}
