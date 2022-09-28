namespace Memorabilia.Application.Features.Admin.GloveTypes
{
    public class GetGloveTypes
    {
        public class Handler : QueryHandler<Query, GloveTypesViewModel>
        {
            private readonly IGloveTypeRepository _gloveTypeRepository;

            public Handler(IGloveTypeRepository gloveTypeRepository)
            {
                _gloveTypeRepository = gloveTypeRepository;
            }

            protected override async Task<GloveTypesViewModel> Handle(Query query)
            {
                return new GloveTypesViewModel(await _gloveTypeRepository.GetAll().ConfigureAwait(false));
            }
        }

        public class Query : IQuery<GloveTypesViewModel> { }
    }
}
